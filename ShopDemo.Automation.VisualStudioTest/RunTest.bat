echo "Running for Internet Explorer"
set browser=InternetExplorer
vstest.console.exe D:\sarsu\SeleniumProjects\ShopDemo.Test\ShopDemo.Automation.VisualStudioTest\bin\Debug\ShopDemo.Automation.VisualStudioTest.dll

echo "Running for Chrome"
set browser=chrome
vstest.console.exe D:\sarsu\SeleniumProjects\ShopDemo.Test\ShopDemo.Automation.VisualStudioTest\bin\Debug\ShopDemo.Automation.VisualStudioTest.dll

echo "Running for Firefox"
set browser=Firefox
vstest.console.exe D:\sarsu\SeleniumProjects\ShopDemo.Test\ShopDemo.Automation.VisualStudioTest\bin\Debug\ShopDemo.Automation.VisualStudioTest.dll





