#region License
//
//   Copyright 2009 Marek Tihkan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License
//
#endregion

using System;
using System.Linq;
using System.Reflection;
using Arc.Domain.Dsl;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Mapping.AutoMapper
{
    public class MappingConfiguration : IConfiguration<IServiceLocator>
    {
    	private readonly Assembly[] _assemblies;

    	public static MappingConfiguration Default(params Assembly[] assemblies)
        {
            return new MappingConfiguration(assemblies);
        }

    	protected MappingConfiguration(Assembly[] assemblies)
    	{
    		_assemblies = assemblies;
    	}

    	public virtual void Load(IServiceLocator handler)
    	{
    		handler.Register(
                Requested.Service<IMapper>().IsImplementedBy<Mapper>().LifeStyle.IsSingelton()
            );

    		ConfigureMaps();
    	}

    	private void ConfigureMaps()
    	{
    		_assemblies.SelectMany(x => x.GetTypes())
    			.Where(x => x.GetInterface(typeof(IMapperConfiguration).FullName) != null)
    			.Each(x =>
    			      	{
    			      		var mapping = (IMapperConfiguration)Activator.CreateInstance(x);
    			      		mapping.Configure();
    			      	});
    	}
    }
}