Imports System.Data.SqlClient
Public Class main
    Dim con As SqlConnection = New SqlConnection("Data Source=ADMIN-PC\SQLEXPRESS; Database=db_project; Trusted_Connection =yes;")
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim connection As String
    Friend ID As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'view in listview
        listviewOne()
    End Sub
    'Search Button
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim str As String = "Select * From tbl_info where fisrtname = '" + TextBox1.Text + "' Or middlename = '" + TextBox1.Text + "'Or lastname = '" + TextBox1.Text + "'"
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim TABLE As New DataTable
        Dim i As Integer

        With cmd
            .CommandText = str
            .Connection = con
        End With

        With da
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        ListView1.Items.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With ListView1
                .Items.Add(TABLE.Rows(i)("stud_id"))

                With .Items(.Items.Count - 1).SubItems
                    'Respondent Profile
                    .Add(TABLE.Rows(i)("fisrtname"))
                    .Add(TABLE.Rows(i)("middlename"))
                    .Add(TABLE.Rows(i)("lastname"))
                    .Add(TABLE.Rows(i)("address"))
                    .Add(TABLE.Rows(i)("number"))
                    .Add(TABLE.Rows(i)("gender"))
                    .Add(TABLE.Rows(i)("birthday"))
                    .Add(TABLE.Rows(i)("date"))
                    .Add(TABLE.Rows(i)("age"))

                End With
            End With
        Next
        con.Close()
    End Sub
    'for selecting in listview
    Private Sub ListView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        ID = ListView1.SelectedItems(0).Text
    End Sub
    'add button
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        add.Show()
        Me.Hide()
    End Sub
    'view in listview
    Private Sub listviewOne()
        Dim str As String = "Select * From tbl_info"
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim TABLE As New DataTable
        Dim i As Integer

        With cmd
            .CommandText = str
            .Connection = con
        End With
        With da
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        ListView1.Items.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With ListView1
                .Items.Add(TABLE.Rows(i)("stud_id"))

                With .Items(.Items.Count - 1).SubItems
                    'Respondent Profile
                    .Add(TABLE.Rows(i)("fisrtname"))
                    .Add(TABLE.Rows(i)("lastname"))
                    .Add(TABLE.Rows(i)("middlename"))
                    .Add(TABLE.Rows(i)("address"))
                    .Add(TABLE.Rows(i)("number"))
                    .Add(TABLE.Rows(i)("gender"))
                    .Add(TABLE.Rows(i)("birthday"))
                    .Add(TABLE.Rows(i)("date"))
                    .Add(TABLE.Rows(i)("age"))
                End With
            End With
        Next
        con.Close()
    End Sub
    'edit button
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ID = Nothing Then
            MsgBox("Please choose a record to edit.", MsgBoxStyle.Exclamation)
        Else
            Panelone.Hide()

            Dim cmd As SqlCommand
            Dim query As String = "SELECT * FROM tbl_info WHERE stud_id='" + ListView1.SelectedItems(0).Text + "'"
            cmd = New SqlCommand(query, con)
            Try
                con.Open()
                Dim myreader As SqlDataReader = cmd.ExecuteReader()
                If myreader.Read() Then
                    Label11.Text = myreader.GetValue(0)
                    TextBox7.Text = myreader.GetValue(1)
                    TextBox5.Text = myreader.GetValue(2)
                    TextBox4.Text = myreader.GetValue(3)
                    TextBox3.Text = myreader.GetValue(5)
                    ComboBox1.Text = myreader.GetValue(6)
                    DateTimePicker1.Text = myreader.GetValue(7)
                    DateTimePicker2.Text = myreader.GetValue(8)
                    TextBox2.Text = myreader.GetValue(4)
                End If
                myreader.Close()
            Catch ex As System.Exception
                MsgBox(ex.Message)
            End Try
            ID = Nothing
            listviewOne()

        End If
        con.Close()
    End Sub
    'cancel button
    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Panelone.Show()
    End Sub
    'delete button
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ID = Nothing Then
            MsgBox("Please choose a record to delete.", MsgBoxStyle.Exclamation)
        Else
            Dim result As Integer = MessageBox.Show("Do you want to delete this item with ID#" + ListView1.SelectedItems(0).Text + "?", "caption", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Try

                    Dim str As String = "DELETE from tbl_info where stud_id = '" + ListView1.SelectedItems(0).Text + "'"
                    Dim da As New SqlDataAdapter(str, con)
                    Dim ds As New DataSet
                    da.Fill(ds, "db_project")
                Catch ex As Exception
                    MsgBox(ex.Message)

                End Try
                MsgBox("Information Deleted!")
            End If
            ID = Nothing
            listviewOne()

        End If
    End Sub
    'updating info
    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        cmd = New SqlCommand("Update tbl_info Set fisrtname = '" + TextBox7.Text + "', middlename = '" + TextBox4.Text + "', lastname = '" + TextBox5.Text + "', number = '" + TextBox3.Text + "', Gender = '" + ComboBox1.Text + "', birthday = '" + DateTimePicker1.Text + "',age = '" + TextBox6.Text + "',address = '" + TextBox2.Text + "', date = '" + DateTimePicker2.Text + "' where stud_id = '" + Label11.Text + "'", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds, "db_info")
        MsgBox("Save")
        Panelone.Show()
        listviewOne()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        listviewOne()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        LoginForm1.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
            And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'Allowed space
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        ' Allowed backspace
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
            And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'Allowed space
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        ' Allowed backspace
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
            And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'Allowed space
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        ' Allowed backspace
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim selStart As Integer = TextBox3.SelectionStart
        Dim selMoveLeft As Integer = 0
        Dim newStr As String = "" 'Build a new string by copying each valid character from the existing string. The new string starts as blank and valid characters are added 1 at a time.

        For i As Integer = 0 To TextBox3.Text.Length - 1

            If "0123456789".IndexOf(TextBox3.Text(i)) <> -1 Then 'Characters that are in the allowed set will be added to the new string.
                newStr = newStr & TextBox3.Text(i)

            ElseIf i < selStart Then 'Characters that are not valid are removed - if these characters are before the cursor, we need to move the cursor left to account for their removal.
                selMoveLeft = selMoveLeft + 1

            End If
        Next

        TextBox3.Text = newStr 'Place the new text into the textbox.
        TextBox3.SelectionStart = selStart - selMoveLeft 'Move the cursor to the appropriate location.

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        With DateTimePicker1.Value
            Dim celebrate As DateTime = New DateTime(Now.Year, .Month, .Day)
            Dim age As Integer = Now.Year - .Year
            If celebrate > Now Then age -= 1
            TextBox6.Text = CStr(age)
        End With
    End Sub
End Class
