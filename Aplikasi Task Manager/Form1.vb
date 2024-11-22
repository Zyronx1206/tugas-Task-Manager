Imports System.Diagnostics
Imports System.Security.Principal

Public Class Form1
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Mengatur kolom DataGridView
        SetupDataGridViewColumns()
        LoadProcesses()
    End Sub

    Private Sub SetupDataGridViewColumns()
        ' Menghapus kolom default
        dataGridViewProcesses.Columns.Clear()

        ' Menambahkan kolom secara manual
        dataGridViewProcesses.Columns.Add("PID", "ID Proses")
        dataGridViewProcesses.Columns.Add("ProcessName", "Nama Proses")
        dataGridViewProcesses.Columns.Add("Memory", "Memori (MB)")
        dataGridViewProcesses.Columns.Add("Status", "Status")

        ' Mengatur lebar kolom
        dataGridViewProcesses.Columns(0).Width = 100  ' ID Proses
        dataGridViewProcesses.Columns(1).Width = 200  ' Nama Proses
        dataGridViewProcesses.Columns(2).Width = 150  ' Memori
        dataGridViewProcesses.Columns(3).Width = 100  ' Status

        ' Membuat kolom tidak dapat disunting
        For Each column As DataGridViewColumn In dataGridViewProcesses.Columns
            column.ReadOnly = True
        Next
    End Sub

    Private Sub LoadProcesses()
        ' Mengosongkan DataGridView
        dataGridViewProcesses.Rows.Clear()

        ' Mendapatkan semua proses yang berjalan
        Dim processes() As Process = Process.GetProcesses()

        ' Menambahkan proses ke DataGridView
        For Each proc As Process In processes
            Try
                dataGridViewProcesses.Rows.Add(
                    proc.Id,
                    proc.ProcessName,
                    String.Format("{0:N2}", proc.WorkingSet64 / 1024 / 1024),
                    If(proc.Responding, "Aktif", "Tidak Respons")
                )
            Catch ex As Exception
                ' Mengabaikan proses yang tidak dapat diakses
            End Try
        Next

        ' Menyesuaikan ukuran kolom
        dataGridViewProcesses.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Function IsRunAsAdministrator() As Boolean
        Dim principal As WindowsPrincipal = New WindowsPrincipal(WindowsIdentity.GetCurrent())
        Return principal.IsInRole(WindowsBuiltInRole.Administrator)
    End Function

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRefresh.Click
        LoadProcesses()
    End Sub

   Private Sub btnEndProcess_Click(sender As Object, e As EventArgs) Handles btnEndProcess.Click
        ' Periksa apakah ada baris yang dipilih
        If dataGridViewProcesses.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih proses yang ingin diakhiri.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Ambil nama proses dari baris yang dipilih
            Dim processName As String = dataGridViewProcesses.SelectedRows(0).Cells(1).Value.ToString()

            ' Konfirmasi penghentian proses
            Dim konfirmasi As DialogResult = MessageBox.Show( _
                "Anda yakin ingin menghentikan proses " & processName & "?", _
                "Konfirmasi", _
                MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question)

            ' Jika dikonfirmasi
            If konfirmasi = DialogResult.Yes Then
                ' Cari dan hentikan semua proses dengan nama tersebut
                Dim processes() As Process = Process.GetProcessesByName(processName)

                For Each proc As Process In processes
                    Try
                        proc.Kill()
                    Catch ex As Exception
                        MessageBox.Show("Gagal menghentikan " & processName & ": " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next

                ' Refresh daftar proses
                LoadProcesses()

                MessageBox.Show("Proses " & processName & " telah dihentikan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class