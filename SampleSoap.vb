Const  username As String = "username"
Const  password As String = "password"
Const  from As String = "5000..."
Const  toNum As String = "09123456789"
Const  text As String = "تست وب سرویس ملی پیامک"
Const  isFlash As Boolean = False
Dim soapClient As New SendSoapClient()
soapClient.SendSimpleSMS2(username, password, toNum, from, text, isFlash)
'یا برای ارسال به مجموعه ای از مخاطبین
soapClient.SendSimpleSMS(username, password, New String() {toNum}, from, text, isFlash)
//ارسال از خط خدماتی اشتراکی
soapClient.SendByBaseNumber2(username, password, text, to, bodyId)

' وب سرویس پیامک
Dim restClient As New RestClient(username, password)
Dim soapClient As New SendSoapClient()
' وب سرویس تیکت پشتیبانی
Dim ticketClient As New TicketsSoapClient()
' وب سرویس برای مدیریت کامل  ارسال انبوه پیامک
Dim actionClient As New ActionsSoapClient()
'وب سرویس کاربران
Dim usersClient As New UsersSoapClient()
'وب سرویس دفترچه تلفن
Dim contactClient As New ContactsSoapClient()
'وب سرویس زمان بندی
Dim scheduleClient As New ScheduleSoapClient()
'وب سرویس پیام صوتی
Dim voiceClient As New VoiceSoapClient()
'وب سرویس دریافت
Dim receiveClient As New ReceiveSoapClient()

'دریافت وضعیت ارسال
soapClient.GetDelivery(recId)
soapClient.GetDeliveries(recIds[], username, password)


'لیست پیامک ها
' جهت دریافت به صورت رشته ای
soapClient.getMessages(username, password, location, from, index, count)
'جهت دریافت بر اساس تاریخ
receiveClient.GetMessagesByDate(username, password, location, from, index, count, dateFrom, dateTo)
' جهت دریافت پیام های کاربران بر اساس تاریخ 
receiveClient.GetUsersMessagesByDate(username, password, location, from, index, count, dateFrom, dateTo)


'موجودی
soapClient.GetCredit(username, password)
'تعرفه پایه / دریافت قیمت قبل از ارسال
soapClient.GetSmsPrice(username, password, irancellCount, mtnCount, from, text)
'لیست شماره اختصاصی
usersClient.GetUserNumbers(username, password)
'بررسی تعداد پیامک های دریافتی
soapClient.GetInboxCount(username, password, isRead)
'ارسال پیامک پیشرفته
soapClient.SendSms(username, password, toNums[], from, text, isflash, udh, recId[], status[])
'مشاهده مشخصات پیام
receiveClient.GetMessagesReceptions(username, password, msgId, fromRows)
'حذف پیام دریافتی
receiveClient.RemoveMessages2(username, password, location, msgIds)
'ارسال زماندار
scheduleClient.AddSchedule(username, password, toNum, from, text, isflash, scheduleDateTime, period)
'ارسال زماندار متناظر
scheduleClient.AddMultipleSchedule(username, password, toNums[], from, text[], isflash, scheduleDateTime[], period)
'ارسال سررسید
scheduleClient.AddNewUsance(username, password, toNum, from, text, isflash, scheduleStartDateTime, countRepeat, scheduleEndDateTime, periodType)
'مشاهده وضعیت ارسال زماندار
scheduleClient.GetScheduleStatus(username, password, schId)
'حذف پیامک زماندار
scheduleClient.RemoveSchedule(username, password, schId)
'ارسال پیامک همراه با تماس صوتی
voiceClient.SendSMSWithSpeechText(username, password, smsBody, speechBody, from, toNum)
'ارسال پیامک همراه با تماس صوتی به صورت زمانبندی
voiceClient.SendSMSWithSpeechTextBySchduleDate(username, password, smsBody, speechBody, from, toNum, scheduleDate)
'دریافت وضعیت پیامک همراه با تماس صوتی
voiceClient.GetSendSMSWithSpeechTextStatus(username, password, recId)


'وب سرویس ارسال انبوه/منطقه ای
'دریافت شناسه شاخه های بانک شماره
actionClient.GetBranchs(username, password, owner)
'اضافه کردن یک بانک شماره جدید
actionClient.AddBranch(username, password, branchName, owner)
'اضافه کردن شماره به بانک
actionClient.AddNumber(username, password, branchId, mobileNumbers[])
' حذف یک بانک
actionClient.RemoveBranch(username, password, branchId)
' ارسال انبوه از طریق بانک
actionClient.AddBulk(username, password, from, branch, bulkType, title, message, rangeFrom, rangeTo, DateToSend, requestCount, rowFrom)
' تعداد شماره های موجود
actionClient.GetBulkCount(username, password, branch, rangeFrom, rangeTo)
' گزارش گیری از ارسال انبوه
actionClient.GetBulkReceptions(username, password, bulkId, fromRows)
' تعیین وضعیت ارسال 
actionClient.GetBulkStatus(username, password, bulkId, sent, failed, status)
' تعداد ارسال های امروز
actionClient.GetTodaySent(username, password)
' تعداد ارسال های کل
actionClient.GetTodaySent(username, password)
' حذف ارسال منطقه ای
actionClient.RemoveBulk(username, password, bulkId)
' ارسال متناظر
actionClient.SendMultipleSMS(username, password, toNums[], from, text[], isflash, udh, recId[], status)
' نمایش دهنده وضعیت گزارش گیری
actionClient.UpdateBulkDelivery(username, password, bulkId)


' وب سرویس تیکت
' ثبت تیکت جدید
ticketClient.AddTicket(username, password, title, content, aletWithSms)
' جستجو و دریافت تیکت ها
ticketClient.GetReceivedTickets(username, password, ticketOwner, ticketType, keyword)
' دریافت تعداد تیکت های کاربران
ticketClient.GetReceivedTicketsCount(username, password, ticketType)
' دریافت تیکت های ارسال شده
ticketClient.GetSentTickets(username, password, ticketOwner, ticketType, keyword)
' دریافت تعداد تیکت های ارسال شده
ticketClient.GetSentTicketsCount(username, password, ticketType)
' پاسخگویی به تیکت
ticketClient.ResponseTicket(username, password, ticketId, type, content, alertWithSms)


' وب سرویس دفترچه تلفن
' اضافه کردن گروه جدید
contactsClient.AddGroup(username, password, groupName, Descriptions, showToChilds)
' اضافه کردن کاربر جدید
contactsClient.AddContact(username, password, options)
' بررسی موجود بودن شماره در دفترچه تلفن
contactsClient.CheckMobileExistInContact(username, password, mobileNumber)
' دریافت اطلاعات دفترچه تلفن
contactsClient.GetContacts(username, password, groupId, keyword, count)
' دریافت گروه ها
contactsClient.GetGroups(username, password)
' ویرایش مخاطب
contactsClient.ChangeContact(username, password, options)
' حذف مخاطب
contactsClient.RemoveContact(username, password, mobilenumber)
' دریافت اطلاعات مناسبت های فرد
contactsClient.GetContactEvents(username, password, contactId)


' وب سرویس کاربران
' ثبت فیش واریزی
usersClient.AddPayment(username, password, options)
' اضافه کردن کاربر جدید در سامانه
usersClient.AddUser(username, password, options)
' اضافه کردن کاربر جدید در سامانه(کامل)
usersClient.AddUserComplete(username, password, options)
' اضافه کردن کاربر جدید در سامانه(WithLocation)
usersClient.AddUserWithLocation(username, password, options)
' بدست آوردن ID کاربر
usersClient.AuthenticateUser(username, password)
' تغییر اعتبار
usersClient.ChangeUserCredit(username, password, amount, description, targetUsername, GetTax)
' فراموشی رمز عبور
usersClient.ForgotPassword(username, password, mobileNumber, emailAddress, targetUsername)
' دریافت تعرفه پایه کاربر
usersClient.GetUserBasePrice(username, password, targetUsername)
' دریافت اعتبار کاربر
usersClient.GetUserCredit(username, password, targetUsername)
' دریافت مشخصات کاربر
usersClient.GetUserDetails(username, password, targetUsername)
' دریافت شماره های کاربر
usersClient.GetUserNumbers(username, password)
' دریافت تراکنش های کاربر
usersClient.GetUserTransactions(username, password, targetUsername, creditType, dateFrom, dateTo, keyword)
' دریافت اطلاعات  کاربران
usersClient.GetUsers(username, password)
' دریافت اطلاعات  فیلترینگ
usersClient.HasFilter(username, password, text)
'  حذف کاربر
usersClient.RemoveUser(username, password, targetUsername)
' مشاهده استان ها
usersClient.GetProvinces(username, password)
' مشاهده کد شهرستان 
usersClient.GetCities(username, password, provinceId)
' مشاهده تاریخ انقضای کاربر 
usersClient.GetExpireDate(username, password)
