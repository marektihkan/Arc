class Path
  def self.to
    PathRootBuilder.new ''
  end
end

class PathBuilder
  def initialize(root)
    @root = root
  end

  def any
    directory "*"
  end

  def directory(name)
    path = ((@root.empty?) ? '' : "#{@root}/") + name
    PathBuilder.new path
  end

  def file(name)
    directory(name).to_s
  end

  def root
    @root
  end

  def method_missing(method_name, *args)
    directory method_name.to_s
  end

  def to_s
    @root
  end
end


class PathRootBuilder < PathBuilder
  def build
    BuildPathBuilder.new 'build'
  end
  
  def source
    directory 'Source'
  end
  
  def tests
    directory 'Tests'
  end
  
  def libraries
    directory 'External Libraries'
  end

  def tools
    directory 'Tools'
  end
end

class BuildPathBuilder < PathBuilder
  def binary
    directory 'bin'
  end
  
  def tests
    directory 'tests'
  end
  
  def documentation
    directory 'doc'
  end
  
  def results
    directory 'results'
  end
  
  def publish
    PublishPathBuilder.new "#{@root}/publish"
  end
end

class PublishPathBuilder < PathBuilder
  def ioc
     directory 'ServiceLocators'
  end

  def validation
    directory 'Validation'
  end

  def logging
    directory 'Logging'
  end

  def data
    directory 'Data'
  end
end