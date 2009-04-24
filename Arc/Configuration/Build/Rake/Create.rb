require 'erb'

class Create

  def self.directory(name)
    Dir.mkdir name unless exists?(name)  
  end

  def self.versioning_file
    VersionFileBuilder.new
  end
end


class VersionFileBuilder

    def initialize
      @properties = {'Product' => 'Unknown', 'Version' => '0.0.0.0', 'InformationalVersion' => '0.0.0.0'}
    end

    def for_product_named(name)
      @properties['Product'] = name
      self
    end

    def versioned(version)
      @properties['Version'] = @properties['InformationalVersion'] = version + '.' + (ENV["CCNetLabel"].nil? ? '0' : ENV["CCNetLabel"].to_s)
      self
    end

    def reserve_all_rights_to(owner)
      @properties['Copyright'] = "Copyright 2008 - 2009 #{owner}. All rights reserved."
      self
    end

	def to(file)
		template = %q{
using System;
using System.Reflection;
using System.Runtime.InteropServices;

<% @properties.each {|k, v| %>
[assembly: Assembly<%=k%>Attribute("<%=v%>")]
<% } %>
		}.gsub(/^    /, '')

	  erb = ERB.new(template, 0, "%<>")

	  File.open(file, 'w') do |file|
		  file.puts erb.result(binding)
	  end
	end
end