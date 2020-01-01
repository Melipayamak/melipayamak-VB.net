Imports System.Net.Http
Imports Newtonsoft.Json

Public Class RestClientAsync
	Private Const endpoint = "https://rest.payamak-panel.com/api/SendSMS/"
	Private Const sendOp = "SendSMS"
	Private Const getDeliveryOp = "GetDeliveries2"
	Private Const getMessagesOp = "GetMessages"
	Private Const getCreditOp = "GetCredit"
	Private Const getBasePriceOp = "GetBasePrice"
	Private Const getUserNumbersOp = "GetUserNumbers"
	Private Const sendByBaseNumberOp = "BaseServiceNumber"
	Private UserName As String
	Private Password As String

	Public Sub New(ByVal username As String, ByVal password As String)
		username = username
		password = password
	End Sub

	Private Async Function makeRequestAsync(ByVal values As Dictionary(Of String, String), ByVal op As String) As Task(Of RestResponse)
		Dim content = New FormUrlEncodedContent(values)

		Using httpClient = New HttpClient
			Dim response = Await httpClient.PostAsync(endpoint & op, content)
			Dim responseString = Await response.Content.ReadAsStringAsync
			Return JsonConvert.DeserializeObject(Of RestResponse)(responseString)
		End Using
	End Function

	Public Async Function SendAsync(ByVal [to] As String, ByVal from As String, ByVal message As String, ByVal isflash As Boolean) As Task(Of RestResponse)
		Dim values = New Dictionary(Of String, String) From {
			{"username", UserName},
			{"password", Password},
			{"to", [to]},
			{"from", from},
			{"text", message},
			{"isFlash", isflash.ToString}
		}
		Return Await makeRequestAsync(values, sendOp)
	End Function

	Public Async Function SendByBaseNumberAsync(ByVal text As String, ByVal [to] As String, ByVal bodyId As Integer) As Task(Of RestResponse)
		Dim values = New Dictionary(Of String, String) From {
			{"username", UserName},
			{"password", Password},
			{"text", text},
			{"to", [to]},
			{"bodyId", bodyId.ToString}
		}
		Return Await makeRequestAsync(values, sendByBaseNumberOp)
	End Function

	Public Async Function GetDeliveryAsync(ByVal recid As Long) As Task(Of RestResponse)
		Dim values = New Dictionary(Of String, String) From {
			{"UserName", UserName},
			{"PassWord", Password},
			{"recID", recid.ToString}
		}
		Return Await makeRequestAsync(values, getDeliveryOp)
	End Function

	Public Async Function GetMessagesAsync(ByVal location As Integer, ByVal from As String, ByVal index As String, ByVal count As Integer) As Task(Of RestResponse)
		Dim values = New Dictionary(Of String, String) From {
			{"UserName", UserName},
			{"PassWord", Password},
			{"Location", location.ToString},
			{"From", from},
			{"Index", index},
			{"Count", count.ToString}
		}
		Return Await makeRequestAsync(values, getMessagesOp)
	End Function

	Public Async Function GetCreditAsync() As Task(Of RestResponse)
		Dim values = New Dictionary(Of String, String) From {
			{"UserName", UserName},
			{"PassWord", Password}
		}
		Return Await makeRequestAsync(values, getCreditOp)
	End Function

	Public Async Function GetBasePriceAsync() As Task(Of RestResponse)
		Dim values = New Dictionary(Of String, String) From {
			{"UserName", UserName},
			{"PassWord", Password}
		}
		Return Await makeRequestAsync(values, getBasePriceOp)
	End Function

	Public Async Function GetUserNumbersAsync() As Task(Of RestResponse)
		Dim values = New Dictionary(Of String, String) From {
			{"UserName", UserName},
			{"PassWord", Password}
		}
		Return Await makeRequestAsync(values, getUserNumbersOp)
	End Function
End Class
