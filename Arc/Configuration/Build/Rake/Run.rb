class Run
  def self.MSBuild
    RunMSBuildCommand.new
  end

  def self.xUnitTests
    NUnitCommand.new
  end

  def self.CodeCoverageAnalysis
    NCoverCommand.new
  end
end

class NCoverCommand
  NCOVER_PATH = Path.to.tools.ncover.root
  NUNIT_PATH = Path.to.tools.nunit.bin

  def logs_to(path)
    @log = path.to_s
    self
  end

  def outputs_to(path)
    @output = path.to_s.gsub('/','\\')
    self
  end

  def for(assembly_names)
    @assemblies = ''
    assembly_names.each do |assembly|
      @assemblies += "#{assembly}.dll "
    end

    xunit_executable = "#{NUNIT_PATH}/nunit.console.exe".gsub('/','\\')
    executable = "#{NCOVER_PATH}/NCover.Console.exe".gsub('/','\\')
    sh "#{executable} \"#{xunit_executable}\" #{@assemblies} //x \"#{@output}\""
  end
end

class NUnitCommand
  NUNIT_PATH = 'Tools/nunit/bin'
  OPTIONS = '/nothread /nologo /nodots'

  def initialize
    @platform = 'x86'
    define_paths
  end

  def located_at(path)
    @path = path.to_s
    self
  end

  def on_platform(platform)
    @platform = platform
    define_paths
    self
  end

  def save_results_to(path)
    @output = path.to_s
    self
  end

  def define_paths()
    exe_file = "nunit-console#{(@platform.empty? ? '' : "-#{@platform}")}.exe"
    @nunit_console_path = File.join(NUNIT_PATH, exe_file).gsub('/','\\') + ' ' + OPTIONS
  end
  
  def from_assembly(assembly)
	file = File.expand_path("#{@path}/#{assembly}.dll")
    outputFile = File.expand_path("#{@output}/TestResults-#{assembly}.xml")
	sh "#{@nunit_console_path} /xml:\"#{outputFile}\" #{file}"
    self
  end
end

class RunMSBuildCommand
    def initialize
      @version = 'v3.5'
      @configuration = 'debug'
    end

    def version (version)
      @version = version
      self
    end

    def with_configuration(configuration)
      @configuration = configuration
      self
    end

    def for_solution(solution)
      @solution = "#{solution}.sln"
      self
    end
  
	def build
		frameworkDir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', @version)
		msbuildFile = File.join(frameworkDir, 'msbuild.exe')

		sh "#{msbuildFile} #{@solution} /nologo /maxcpucount /v:m /property:BuildInParallel=false /property:Configuration=#{@configuration} /t:Build"
    end

  def rebuild
		frameworkDir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', @version)
		msbuildFile = File.join(frameworkDir, 'msbuild.exe')

		sh "#{msbuildFile} #{@solution} /nologo /maxcpucount /v:m /property:BuildInParallel=false /property:Configuration=#{@configuration} /t:Rebuild"
	end
end