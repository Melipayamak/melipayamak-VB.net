Public Class RestClient

    Private Const endpoint As String = "https://rest.payamak-panel.com/api/SendSMS/"

    Private Const sendOp As String = "SendSMS"

    Private Const getDeliveryOp As String = "GetDeliveries2"

    Private Const getMessagesOp As String = "GetMessages"

    Private Const getCreditOp As String = "GetCredit"

    Private Const getBasePriceOp As String = "GetBasePrice"

    Private Const getUserNumbersOp As String = "GetUserNumbers"

    Private UserName As String

    Private Password As String

    Public Sub New(ByVal username As String, ByVal password As String)
        UserName = username
        Password = password
    End Sub

    Public Function Send(ByVal [to] As String, ByVal from As String, ByVal message As String, ByVal isflash As Boolean) As RestResponse
        Dim values = New Dictionary(Of String, String) From {{"username", UserName}, {"password", Password}, {"to", [to]}, {"from", from}, {"text", message}, {"isFlash", isflash.ToString()}}
        Dim content = New FormUrlEncodedContent(values)
        Using httpClient = New HttpClient()
            Dim response = httpClient.PostAsync(endpoint & sendOp, content).Result
            Dim responseString = response.Content.ReadAsStringAsync().Result
            Return JsonConvert.DeserializeObject(Of RestResponse)(responseString)
        End Using
    End Function

    Public Function GetDelivery(ByVal recid As Long) As RestResponse
        Dim values = New Dictionary(Of String, String) From {{"UserName", UserName}, {"PassWord", Password}, {"recID", recid.ToString()}}
        Dim content = New FormUrlEncodedContent(values)
        Using httpClient = New HttpClient()
            Dim response = httpClient.PostAsync(endpoint & getDeliveryOp, content).Result
            Dim responseString = response.Content.ReadAsStringAsync().Result
            Return JsonConvert.DeserializeObject(Of RestResponse)(responseString)
        End Using
    End Function

    Public Function GetMessages(ByVal location As Integer, ByVal from As String, ByVal index As String, ByVal count As Integer) As RestResponse
        Dim values = New Dictionary(Of String, String) From {{"UserName", UserName}, {"PassWord", Password}, {"Location", location.ToString()}, {"From", from}, {"Index", index}, {"Count", count.ToString()}}
        Dim content = New FormUrlEncodedContent(values)
        Using httpClient = New HttpClient()
            Dim response = httpClient.PostAsync(endpoint & getMessagesOp, content).Result
            Dim responseString = response.Content.ReadAsStringAsync().Result
            Return JsonConvert.DeserializeObject(Of RestResponse)(responseString)
        End Using
    End Function

    Public Function GetCredit() As RestResponse
        Dim values = New Dictionary(Of String, String) From {{"UserName", UserName}, {"PassWord", Password}}
        Dim content = New FormUrlEncodedContent(values)
        Using httpClient = New HttpClient()
            Dim response = httpClient.PostAsync(endpoint & getCreditOp, content).Result
            Dim responseString = response.Content.ReadAsStringAsync().Result
            Return JsonConvert.DeserializeObject(Of RestResponse)(responseString)
        End Using
    End Function

    Public Function GetBasePrice() As RestResponse
        Dim values = New Dictionary(Of String, String) From {{"UserName", UserName}, {"PassWord", Password}}
        Dim content = New FormUrlEncodedContent(values)
        Using httpClient = New HttpClient()
            Dim response = httpClient.PostAsync(endpoint & getBasePriceOp, content).Result
            Dim responseString = response.Content.ReadAsStringAsync().Result
            Return JsonConvert.DeserializeObject(Of RestResponse)(responseString)
        End Using
    End Function

    Public Function GetUserNumbers() As RestResponse
        Dim values = New Dictionary(Of String, String) From {{"UserName", UserName}, {"PassWord", Password}}
        Dim content = New FormUrlEncodedContent(values)
        Using httpClient = New HttpClient()
            Dim response = httpClient.PostAsync(endpoint & getUserNumbersOp, content).Result
            Dim responseString = response.Content.ReadAsStringAsync().Result
            Return JsonConvert.DeserializeObject(Of RestResponse)(responseString)
        End Using
    End Function
End Class

Public Class RestResponse

    Public Property Value As String

    Public Property RetStatus As Integer

    Public Property StrRetStatus As String
End Class
