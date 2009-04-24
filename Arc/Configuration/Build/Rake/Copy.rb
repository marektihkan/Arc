class Copy

  def self.binaries
     CopyCommand.new "dll"
  end

  def self.assemblies
     CopyCommand.new "dll,pdb,xml"
  end

  def self.config
    CopyCommand.new "config,cfg.xml"
  end

end

class CopyCommand

  def initialize(extensions)
    @extensions = extensions
    @pattern = '*'
  end

  def from(path)
    @fromPath = path
    self
  end

  def matching(pattern)
    @pattern = pattern
    self
  end

  def to(path)
    Dir.glob(File.join(@fromPath, "#{@pattern}.{#{@extensions}}")) { |file|
      copy(file, path) if File.file?(file)
    }
  end
end