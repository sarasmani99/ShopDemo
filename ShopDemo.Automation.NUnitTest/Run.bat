echo "Test running for chrome"
set browser=chrome
nunit3-console.exe D:\sarsu\SeleniumProjects\ShopDemo.Test\ShopDemo.Automation.NUnitTest\bin\Debug\ShopDemo.Automation.NUnitTest.dll

echo "Test running for Edge"
set browser=Edge
nunit3-console.exe D:\sarsu\SeleniumProjects\ShopDemo.Test\ShopDemo.Automation.NUnitTest\bin\Debug\ShopDemo.Automation.NUnitTest.dll

echo "Test running for Internet Explorer"
set browser=Firefox
nunit3-console.exe D:\sarsu\SeleniumProjects\ShopDemo.Test\ShopDemo.Automation.NUnitTest\bin\Debug\ShopDemo.Automation.NUnitTest.dll

