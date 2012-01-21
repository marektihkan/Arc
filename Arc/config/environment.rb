CONFIG = {
  :paths => { 
    :nunit => 'packages/NUnit.2.5.7.10213/Tools/nunit-console.exe',
	:nuget => 'tools/NuGet.exe'
  },
  :directories => {
    :build => 'build',
    :lib => 'packages',
    :src => 'src',
    :tests => 'tests',
    :configuration => 'config',
    :binary => 'bin',
    :publish => 'package',
	:nuget => 'build/nuget'
  },  
  :solution => 'Arc',
  :owner => 'Marek Tihkan, Siim Viikman',
  :build_configuration => 'Release'
}