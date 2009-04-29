require "ftools"

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

  def self.files(extensions)

  end
end

class CopyCommand
  def initialize(extensions)
    @extensions = extensions
    @pattern = '*'
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
    Dir.glob(File.join(@from_path, "{#{@pattern}}.{#{@extensions}}")) do |file|
      File.copy(file, path.to_s) if File.file?(file)
    end
  end
end