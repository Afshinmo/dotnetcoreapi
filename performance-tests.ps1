<# 
*************************************************************************
Run performancetest with tool 'JMeter'
======================================
Command line parameters for 'JMeter':
-n  This specifies JMeter is to run in non-gui mode.
-t  Name of JMX file that contains the Test Plan.
-l  Name of JTL(JMeter text logs) file to log results.
-j  Name of JMeter run log file.
-g  [path to CSV file] generate report dashboard only.
-o  Output folder where to generate the report dashboard after load test. Folder must not exist or be empty.
-J[prop_name]=[value]  Defines a local JMeter property.
*************************************************************************
#>
write-Host "`n"
$date = Get-date -format "yyyyMMdd_HHmmssfff"
#write-Host "Date: $date"
#write-Host "`n"

$jmeterBat="\\dindator\sdp\Programs\apache-jmeter-3.0\bin\jmeter.bat"
$jmeterJmx=".\test\dotnetcoreapi\dotnetcoreapi.jmx"
$jmeterJtl=".\testresults\dotnetcoreapi.jtl"
$jmeterRunLog=".\testresults\dotnetcoreapi.log"

$url="sokvagenTillPortalen"
$correlationId = "dotnetcoreapi_$date"
$noOfThreads="10"
$rampUpTime="1"
$noOfLoops="1"

write-Host "URL:               $url"
write-Host "correlationId:     $correlationId"
write-Host "Number of threads: $noOfThreads"
write-Host "Ramp-Up time:      $rampUpTime"
write-Host "Number of loops:   $noOfLoops"
write-Host "`n"

# Examples on how to count virtual users
# threadgroup_num_threads=100 threadgroup_ramp_time=1 threadgroup_loops=2
# Number of Threads '100', Ramp-Up Time '1sec'  (1000ms/100threads)  => 1 virtual user for every 10ms.
# Number of Threads '100', Ramp-Up Time '5sec'  (5000ms/100threads)  => 1 virtual user for every 50ms.
# Number of Threads '100', Ramp-Up Time '10sec' (10000ms/100threads) => 1 virtual user for every 100ms.
write-Host "Run JMeter with command:"
$jenkinsCmdRun="$jmeterBat -n -t $jmeterJmx -l $jmeterJtl -j $jmeterRunLog -Jjmeter_url=$url -Jthreadgroup_num_threads=$noOfThreads -Jthreadgroup_ramp_time=$rampUpTime -Jthreadgroup_loops=$noOfLoops -Jheadermanager_correlationId=$correlationId"
write-Host "$jenkinsCmdRun"
write-Host "`n"
cmd.exe /c $jenkinsCmdRun
write-Host "`n"
