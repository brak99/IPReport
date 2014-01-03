..\packages\OpenCover.4.5.2316\OpenCover.Console.exe -register:user -skipautoprops -target:"C:\Program Files (x86)\NUnit 2.6.2\bin\nunit-console-x86.exe" -targetargs:"bin\Debug\IPReport.Test.dll /noshadow" targetdir:bin\Debug -output:opencovertests.xml "-filter:+[IPReport]* -[IPReport.Test]*"

..\packages\ReportGenerator.1.9.1.0\ReportGenerator.exe "-reports:opencovertests.xml" "-targetdir:coverageReport"
