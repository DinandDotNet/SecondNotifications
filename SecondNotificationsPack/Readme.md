SECONDNOTIFICATIONS

This is a example app include the nuget package and the source code. 
You are free to Fork and make it better. 

Note:
After you install SECONDNOTIFICATIONS from Nuget package

Add in startup (see example code for details):
services.AddHttpContextAccessor();  
services.AddSession(); 
app.UseSession();

Add _notifications from pages/shared/ to your shared folder 
or 
Create a new _notifications.cshtml in your shared folder and add the following code:

```html
@* this will also diplay your model errors *@
<div asp-validation-summary="All" class="text-danger"></div> 

@{
    var messages = new SecondNotification().GetNotification();
    foreach (var message in messages)
    {
        <div class="alert @message.Item2 alert-dismissable col-lg-12">
            <a href="#" class="close" data-dismiss="alert">&times;</a>
            <h3><label>@message.Item1</label></h3>
        </div>
    }
}
```

Add in _layout just above @renderbody() (see example for details):

`<partial name="_Notifications" />`


set a Notification:
new SecondNotification().SetNotification("Message", "Bootstrap Alert type");

Ready and go.
