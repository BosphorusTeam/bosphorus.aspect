$files = Get-ChildItem -Recurse AssemblyInfo.cs
Write-Host "Hello"
Write-Host $files
$matchPattern = 'AssemblyFileVersion\(\"(?<major>\d{1,3})\.(?<minor>\d{1,3})\.(?<build>\d{1,3})\.(?<revision>\d{1,3})\"\)'
[regex]$regex = $matchPattern
foreach ($file in $files) 
{
    $content = get-content $file 
	$rawVersionNumber = $content | select-string -pattern $matchPattern
    $match = $regex.Match($rawVersionNumber)
	$currentRevision = $match.Groups["revision"].Value
	$newRevision = ([int]$currentRevision) + 1
	$replacement = 'AssemblyFileVersion("${major}.${minor}.${build}.' + $newRevision + '")'


	Write-Host "Replacing contents of file $file"
	(Get-Content -Raw $file.FullName) | ForEach-Object {$_ -replace $matchPattern, $replacement } | Set-Content -Encoding UTF8 $file.FullName
}

Start-Sleep -s 1
