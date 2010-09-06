require 'fileutils'

class Delete
  def self.directory(path)
    FileUtils.rm_rf path.to_s if File.exist?(path.to_s)
  end
end

class Create
  def self.directory(name)
    Dir.mkdir name.to_s unless File.exist?(name.to_s)  
  end
end

class Copy
  def self.binaries
     CopyCommand.new "dll"
  end

  def self.assemblies
     CopyCommand.new "dll,pdb,xml"
  end

  def self.configuration
    CopyCommand.new "config,cfg.xml"
  end

  def self.all
    CopyCommand.new "*"
  end 

  def self.files(extensions)
	CopyCommand.new extensions
  end
end

class CopyCommand
  def initialize(extensions)
    @extensions = extensions
    @pattern = '*'
	@recursively = false
  end

  def recursively
    @recursively = true
	self
  end

  def from(path)
    @from_path = path.to_s
    self
  end

  def matching(pattern)
    @pattern = pattern
    self
  end

  def to(path)
    Dir.glob(File.join(@from_path.to_s, "{#{@pattern}}.{#{@extensions}}")) do |file|
	  if (@recursively) 
		copy_recursively(file, path)
	  else 
		copy(file, path)
	  end
    end
  end
  
  private
  def copy_recursively(file, path)
    FileUtils.cp_r(file, path.to_s) if File.file?(file)
  end
  
  def copy(file, path)
	FileUtils.cp(file, path.to_s) if File.file?(file)
  end
end