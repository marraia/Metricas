REM Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"

REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

REM Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics

REM Generate the report output based on the test results
if %errorlevel% equ 0 ( 
	call :RunReportGeneratorOutput	
)

REM Launch the report
if %errorlevel% equ 0 ( 
	call :RunLaunchReport	
)
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics
"%~dp0packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%~dp0packages\xunit.runner.console.2.3.1\tools\net452\xunit.console.x86.exe"  ^
-targetargs:"%~dp0FM.Metricas.UnitTest\bin\Debug\FM.Metricas.UnitTest.dll -noshadow" ^
-filter:"+[FM.Metricas*]* -[FM.Metricas.UnitTest]* " ^
-output:"%~dp0\GeneratedReports\FM.Metricas.xml"
exit /b %errorlevel%


:RunReportGeneratorOutput
"%~dp0packages\ReportGenerator.3.0.2\tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\FM.Metricas.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGeneratorOutput" ^
-reporttypes:Xml;Html
exit /b %errorlevel%

:RunLaunchReport
start "report" "%~dp0\GeneratedReports\ReportGeneratorOutput\index.htm"
exit /b %errorlevel%

pause					