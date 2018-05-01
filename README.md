# melipayamak Visual Basic (VB.net)

<div dir='rtl'>

### معرفی وب سرویس ملی پیامک
ملی پیامک یک وب سرویس کامل برای ارسال و دریافت پیامک و پیامک صوتی و مدیریت کامل خدمات دیگر است که براحتی میتوانید از آن استفاده کنید.

<hr>

### نصب

<p>قبل از نصب نیاز به ثبت نام در سایت ملی پیامک دارید.</p>

[**ثبت نام به همراه دریافت 200 پیامک هدیه جهت تست وبسرویس**](http://www.melipayamak.com/)

پس از ثبت نام، وب سرویس‌های ملی پیامک را از طریق آدرسهای زیر به عنوان **Service Reference** به پروژه خود اضافه کنید.

</div>

<div dir='rtl'>
  
#### وب سرویس ارسال پیام

</div>

> [api.payamak-panel.com/post/Send.asmx](http://api.payamak-panel.com/post/Send.asmx)


<div dir='rtl'>
  
#### وب سرویس دریافت پیام

</div>

> [api.payamak-panel.com/post/receive.asmx](http://api.payamak-panel.com/post/receive.asmx)


<div dir='rtl'>
  
#### وب سرویس مدیریت مخاطبین

</div>

> [api.payamak-panel.com/post/contacts.asmx](http://api.payamak-panel.com/post/contacts.asmx)

> [api.payamak-panel.com/post/Actions.asmx](http://api.payamak-panel.com/post/Actions.asmx)

<div dir='rtl'>
  
#### وب سرویس ارسال زماندار

</div>

> [api.payamak-panel.com/post/Schedule.asmx](http://api.payamak-panel.com/post/Schedule.asmx)


<div dir='rtl'>
  
#### وب سرویس پشتیبانی کاربران

</div>

> [api.payamak-panel.com/post/Tickets.asmx](http://api.payamak-panel.com/post/Tickets.asmx)


<div dir='rtl'>
  
#### وب سرویس مدیریت کاربران

</div>

> [api.payamak-panel.com/post/Users.asmx](http://api.payamak-panel.com/post/Users.asmx)


<div dir='rtl'>
  
#### وب سرویس ارسال صوتی

</div>

> [api.payamak-panel.com/post/Voice.asmx](http://api.payamak-panel.com/post/Voice.asmx)

<div dir='rtl'>
  
#### نحوه استفاده

نمونه کد برای ارسال پیامک

</div>


```vb
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
```

<div dir='rtl'>

از آنجا که وب سرویس ملی پیامک تنها محدود به ارسال پیامک نیست شما از طریق زیر میتوانید به وب سرویس ها دسترسی کامل داشته باشید:
</div>

```vb
' وب سرویس پیامک
Dim restClient As New RestClient(username, password)
Dim soapClient As New SendSoapClient()
' وب سرویس تیکت پشتیبانی
Dim ticketSoapClient As New TicketsSoapClient()
' وب سرویس برای مدیریت کامل  ارسال انبوه پیامک
Dim actionSoapClient As New ActionsSoapClient()
'وب سرویس کاربران
Dim usersSoapClient As New UsersSoapClient()
'وب سرویس دفترچه تلفن
Dim contactSoapClient As New ContactsSoapClient()
'وب سرویس زمان بندی
Dim scheduleSoapClient As New ScheduleSoapClient()
'وب سرویس پیام صوتی
Dim voiceSoapClient As New VoiceSoapClient()
'وب سرویس دریافت
Dim receiveSoapClient As New ReceiveSoapClient()
```

<div dir='rtl'>
  
#### تفاوت های وب سرویس پیامک rest و soap

از آنجا که ملی پیامک وب سرویس کاملی رو در اختیار توسعه دهندگان میگزارد برای راحتی کار با وب سرویس پیامک علاوه بر وب سرویس اصلی soap وب سرویس rest رو هم در اختیار توسعه دهندگان گزاشته شده تا راحتتر بتوانند با وب سرویس کار کنند. تفاوت اصلی این دو در تعداد متد هاییست که میتوانید با آن کار کنید. برای کار های پایه میتوان از وب سرویس rest استفاده کرد برای دسترسی بیشتر و استفاده پیشرفته تر نیز باید از وب سرویس باید از وب سرویس soap استفاده کرد. جهت مطالعه بیشتر وب سرویس ها به قسمت وب سرویس پنل خود مراجعه کنید.

<hr/>


###  اطلاعات بیشتر

برای مطالعه بیشتر و دریافت راهنمای وب سرویس ها و آشنایی با پارامتر های ورودی و خروجی وب سرویس به صفحه معرفی
[وب سرویس ملی پیامک](https://github.com/Melipayamak/Webservices)
مراجعه نمایید .


<hr/>


### وب سرویس پیامک

متد های وب سرویس:

</div>

#### ارسال

```vb
restClient.Send(toNum, from, text, isFlash)
soapClient.SendSimpleSMS(username, password, New String() {toNum}, from, text, isFlash)
```
<div dir='rtl'>
  در آرگومان سوم روش soap میتوانید از هر تعداد مخاطب به عنوان آرایه استفاده کنید
</div>

#### دریافت وضعیت ارسال
```vb
restClient.GetDelivery(recId)
soapClient.GetDelivery(recId)
soapClient.GetDeliveries(New Int() {recIds}, username, password)
```

#### لیست پیامک ها

```vb
restClient.GetMessages(location, index, count, from)
soapClient.getMessages(username, password, location, from, index, count)
'جهت دریافت به صورت رشته ای
receiveSoapClient.GetMessagesByDate(username, password, location, from, index, count, dateFrom, dateTo)
'جهت دریافت بر اساس تاریخ
receiveSoapClient.GetUsersMessagesByDate(username, password, location, from, index, count, dateFrom, dateTo)
'جهت دریافت پیام های کاربران بر اساس تاریخ 
```

#### موجودی
```vb
restClient.GetCredit()
soapClient.GetCredit(username, password)
```

#### تعرفه پایه / دریافت قیمت قبل از ارسال
```vb
restClient.GetBasePrice()
soapClient.GetSmsPrice(username, password, irancellCount, mtnCount, from, text)
```
#### لیست شماره اختصاصی
```vb
usersSoapClient.GetUserNumbers(username, password)
```

#### بررسی تعداد پیامک های دریافتی
```vb
soapClient.GetInboxCount(username, password, isRead)
'پیش فرض خوانده نشده 
```

#### ارسال پیامک پیشرفته
```vb
soapClient.SendSms(username, password, toNums[], from, text, isflash, udh, recId[], status[])
```

#### مشاهده مشخصات پیام
```vb
receiveSoapClient.GetMessagesReceptions(username, password, msgId, fromRows)
```


#### حذف پیام دریافتی
```vb
receiveSoapClient.RemoveMessages2(username, password, location, msgIds)
```


#### ارسال زماندار
```vb
scheduleSoapClient.AddSchedule(username, password, toNum, from, text, isflash, scheduleDateTime, period)
```

#### ارسال زماندار متناظر
```vb
scheduleSoapClient.AddMultipleSchedule(username, password, toNums[], from, text[], isflash, scheduleDateTime[], period)
```


#### ارسال سررسید
```vb
scheduleSoapClient.AddNewUsance(username, password, toNum, from, text, isflash, scheduleStartDateTime, countRepeat, scheduleEndDateTime, periodType)
```

#### مشاهده وضعیت ارسال زماندار
```vb
scheduleSoapClient.GetScheduleStatus(username, password, schId)
```

#### حذف پیامک زماندار
```vb
scheduleSoapClient.RemoveSchedule(username, password, schId)
```


####  ارسال پیامک همراه با تماس صوتی
```vb
voiceSoapClient.SendSMSWithSpeechText(username, password, smsBody, speechBody, from, toNum)
```

####  ارسال پیامک همراه با تماس صوتی به صورت زمانبندی
```vb
voiceSoapClient.SendSMSWithSpeechTextBySchduleDate(username, password, smsBody, speechBody, from, toNum, scheduleDate)
```

####  دریافت وضعیت پیامک همراه با تماس صوتی 
```vb
voiceSoapClient.GetSendSMSWithSpeechTextStatus(username, password, recId)
```
<div dir='rtl'>
  
### وب سرویس ارسال انبوه/منطقه ای

</div>

#### دریافت شناسه شاخه های بانک شماره
```vb
actionSoapClient.GetBranchs(username, password, owner)
```


#### اضافه کردن یک بانک شماره جدید
```vb
actionSoapClient.AddBranch(username, password, branchName, owner)
```

#### اضافه کردن شماره به بانک
```vb
actionSoapClient.AddNumber(username, password, branchId, mobileNumbers[])
```

#### حذف یک بانک
```vb
actionSoapClient.RemoveBranch(username, password, branchId)
```

#### ارسال انبوه از طریق بانک
```vb
actionSoapClient.AddBulk(username, password, from, branch, bulkType, title, message, rangeFrom, rangeTo, DateToSend, requestCount, rowFrom)
```

#### تعداد شماره های موجود
```vb
actionSoapClient.GetBulkCount(username, password, branch, rangeFrom, rangeTo)
```

#### گزارش گیری از ارسال انبوه
```vb
actionSoapClient.GetBulkReceptions(username, password, bulkId, fromRows)
```


#### تعیین وضعیت ارسال 
```vb
actionSoapClient.GetBulkStatus(username, password, bulkId, sent, failed, status)
```

#### تعداد ارسال های امروز
```vb
actionSoapClient.GetTodaySent(username, password)
```

#### تعداد ارسال های کل

```vb
actionSoapClient.GetTotalSent(username, password)
```

#### حذف ارسال منطقه ای
```vb
actionSoapClient.RemoveBulk(username, password, bulkId)
```

#### ارسال متناظر
```vb
actionSoapClient.SendMultipleSMS(username, password, toNums[], from, text[], isflash, udh, recId[], status)
```

#### نمایش دهنده وضعیت گزارش گیری

```vb
actionSoapClient.UpdateBulkDelivery(username, password, bulkId)
```
<div dir='rtl'>
  
### وب سرویس تیکت

</div>

#### ثبت تیکت جدید
```vb
ticketSoapClient.AddTicket(username, password, title, content, aletWithSms)
```

#### جستجو و دریافت تیکت ها

```vb
ticketSoapClient.GetReceivedTickets(username, password, ticketOwner, ticketType, keyword)
```

#### دریافت تعداد تیکت های کاربران
```vb
ticketSoapClient.GetReceivedTicketsCount(username, password, ticketType)
```

#### دریافت تیکت های ارسال شده
```vb
ticketSoapClient.GetSentTickets(username, password, ticketOwner, ticketType, keyword)
```

#### دریافت تعداد تیکت های ارسال شده
```vb
ticketSoapClient.GetSentTicketsCount(username, password, ticketType)
```


#### پاسخگویی به تیکت
```vb
ticketSoapClient.ResponseTicket(username, password, ticketId, type, content, alertWithSms)
```
<div dir='rtl'>
  
### وب سرویس دفترچه تلفن

</div>

#### اضافه کردن گروه جدید
```vb
contactsSoapClient.AddGroup(username, password, groupName, Descriptions, showToChilds)
```

#### اضافه کردن کاربر جدید
```vb
contactsSoapClient.AddContact(username, password, options)

```

#### بررسی موجود بودن شماره در دفترچه تلفن
```vb
contactsSoapClient.CheckMobileExistInContact(username, password, mobileNumber)
```

#### دریافت اطلاعات دفترچه تلفن
```vb
contactsSoapClient.GetContacts(username, password, groupId, keyword, count)
```
#### دریافت گروه ها
```vb
contactsSoapClient.GetGroups(username, password)
```
#### ویرایش مخاطب
```vb
contactsSoapClient.ChangeContact(username, password, options)
```

#### حذف مخاطب
```vb
contactsSoapClient.RemoveContact(username, password, mobilenumber)
```
#### دریافت اطلاعات مناسبت های فرد
```vb
contactsSoapClient.GetContactEvents(username, password, contactId)
```

<div dir='rtl'>

### وب سرویس کاربران

</div>

#### ثبت فیش واریزی
```vb
usersSoapClient.AddPayment(username, password, options)
```

#### اضافه کردن کاربر جدید در سامانه
```vb
usersSoapClient.AddUser(username, password, options)

```

#### اضافه کردن کاربر جدید در سامانه(کامل)
```vb
usersSoapClient.AddUserComplete(username, password, options)
```

#### اضافه کردن کاربر جدید در سامانه(WithLocation)
```vb
usersSoapClient.AddUserWithLocation(username, password, options)
```
#### بدست آوردن ID کاربر
```vb
usersSoapClient.AuthenticateUser(username, password)
```
#### تغییر اعتبار
```vb
usersSoapClient.ChangeUserCredit(username, password, amount, description, targetUsername, GetTax)
```

#### فراموشی رمز عبور
```vb
usersSoapClient.ForgotPassword(username, password, mobileNumber, emailAddress, targetUsername)
```
#### دریافت تعرفه پایه کاربر
```vb
usersSoapClient.GetUserBasePrice(username, password, targetUsername)
```

#### دریافت اعتبار کاربر
```vb
usersSoapClient.GetUserCredit(username, password, targetUsername)
```

#### دریافت مشخصات کاربر
```vb
usersSoapClient.GetUserDetails(username, password, targetUsername)
```

#### دریافت شماره های کاربر
```vb
usersSoapClient.GetUserNumbers(username, password)
```

#### دریافت تراکنش های کاربر
```vb
usersSoapClient.GetUserTransactions(username, password, targetUsername, creditType, dateFrom, dateTo, keyword)
```

#### دریافت اطلاعات  کاربران
```vb
usersSoapClient.GetUsers(username, password)
```


#### دریافت اطلاعات  فیلترینگ
```vb
usersSoapClient.HasFilter(username, password, text)
```


####  حذف کاربر
```vb
usersSoapClient.RemoveUser(username, password, targetUsername)
```


#### مشاهده استان ها
```vb
usersSoapClient.GetProvinces(username, password)
```

#### مشاهده کد شهرستان 
```vb
usersSoapClient.GetCities(username, password, provinceId)
```


#### مشاهده تاریخ انقضای کاربر 
```vb
usersSoapClient.GetExpireDate(username, password)
```
