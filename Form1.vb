Public Class Form1
    Dim string1 As String
    Dim string2 As String

    Dim value As String
    Dim rawText As String
    Dim position As Integer
    Dim base As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim answer1 As String = ""
        Dim answer2 As String = ""
        Dim value As String = ""
        Dim collAdd As New Collection
        rawText = TextBox1.Text
        base = TextBox3.Text

        For t = 0 To rawText.Length - 1
            value = rawText.Chars(t)
            answer1 = ""
            answer2 = ""
            raiseTo(base, rawText.Length - 1 - t, answer1)
            multiply(value, answer1, answer2)
            collAdd.Add(answer2)
        Next

        Dim runningTotal As String = "0"
        Dim additionAnswer As String = ""
        For Each addend As String In collAdd
            add(addend, runningTotal, additionAnswer)
            runningTotal = additionAnswer
            additionAnswer = ""
        Next

        TextBox4.Text = runningTotal
    End Sub

    Public Sub raiseTo(base As String, power As Integer, ByRef answer As String)
        Dim runningTotal As String = 1
        Dim additionAnswer As String = ""
        If power = 0 Then
            If base = 0 Then
                answer = 0
            Else
                answer = 1
            End If

        Else
            For t As Integer = 1 To power
                multiply(base, runningTotal, additionAnswer)
                runningTotal = additionAnswer
                additionAnswer = ""
            Next
            answer = runningTotal
        End If

    End Sub

    Public Sub add(x1 As String, x2 As String, ByRef answer As String)
        Dim carry As String = 0
        Dim x1Bit As Integer
        Dim x2bit As Integer
        Dim answerBit As String = 0
        Dim total As String
        answer = ""
        Dim diffLength As Integer = 0

        If x1.Length < x2.Length Then
        Else
            Dim temp As String
            temp = x2
            x2 = x1
            x1 = temp
        End If

        diffLength = x2.Length - x1.Length

        For t As Integer = 1 To diffLength
            x1 = "0" & x1
        Next

        For t As Integer = x1.Length - 1 To 0 Step -1
            x1Bit = Val(x1.Chars(t))
            x2bit = Val(x2.Chars(t))

            total = x1Bit + x2bit + carry

            If total.Length = 2 Then
                carry = total.Chars(0)
                answerBit = total.Chars(1)
            Else
                carry = 0
                answerBit = total
            End If

            answer = answerBit & answer
        Next
        If carry > 0 Then
            answer = carry & answer
        End If

    End Sub
    Public Sub multiply(x1 As String, x2 As String, ByRef answer As String)
        Dim collAddends As New Collection
        Dim x1Bit As Integer
        Dim x2bit As Integer
        Dim total As String
        Dim carry As String = 0
        Dim answerBit As String = 0
        Dim diffLength As Integer = 0

        If x1.Length < x2.Length Then
        Else
            Dim temp As String
            temp = x2
            x2 = x1
            x1 = temp
        End If

        For t As Integer = x1.Length - 1 To 0 Step -1
            carry = 0
            answer = ""
            For t1 As Integer = x2.Length - 1 To 0 Step -1
                x1Bit = Val(x1.Chars(t))
                x2bit = Val(x2.Chars(t1))
                total = x1Bit * x2bit + carry

                If total.Length = 2 Then
                    carry = total.Chars(0)
                    answerBit = total.Chars(1)
                Else
                    carry = 0
                    answerBit = total
                End If
                answer = answerBit & answer
            Next
            If carry > 0 Then
                answer = carry & answer

            End If

            diffLength = x1.Length - 1 - t
            For t2 As Integer = 1 To diffLength
                answer &= "0"
            Next
            collAddends.Add(answer)
        Next

        Dim runningTotal As String = "0"
        Dim additionAnswer As String = ""
        For Each addend As String In collAddends
            add(addend, runningTotal, additionAnswer)
            runningTotal = additionAnswer
            additionAnswer = ""
        Next
        answer = runningTotal
    End Sub
End Class
