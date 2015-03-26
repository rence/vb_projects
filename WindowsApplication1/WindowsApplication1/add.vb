Imports System.Data.SqlClient
Public Class add
    Dim con As SqlConnection = New SqlConnection("Data Source=ADMIN-PC\SQLEXPRESS; Database=db_project; Trusted_Connection =yes;")
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd = New SqlCommand("Insert Into tbl_info (fisrtname, middlename, lastname, age, number, gender, address, date, birthday) Values ('" + TextBox1.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "', '" + TextBox3.Text + "', '" + ComboBox1.Text + "', '" + TextBox2.Text + "', '" + DateTimePicker2.Text + "', '" + DateTimePicker1.Text + "')", con)
        da = New SqlDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds, "db_info")
        Dim result As Integer = MessageBox.Show("Do you want to save this info?", "caption", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            main.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        main.Show()
        Me.Hide()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        With DateTimePicker1.Value
            Dim celebrate As DateTime = New DateTime(Now.Year, .Month, .Day)
            Dim age As Integer = Now.Year - .Year
            If celebrate > Now Then age -= 1
            TextBox6.Text = CStr(age)
        End With
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

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click

    End Sub
End Class