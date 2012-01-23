using System;

namespace Arc.Infrastructure.Dependencies.Registration.Auto
{
	public class RegisterTypeToAllMatchStrategy : BaseRegisterTypeStrategy, ITypeRegistrationStrategy
	{
		private readonly Func<Type, Type, bool> _binding;

		/// <summary>
		/// Initializes a new instance of the <see cref="RegisterTypeToAllMatchStrategy"/> class.
		/// </summary>
		/// <param name="binding">The binding.</param>
		public RegisterTypeToAllMatchStrategy(Func<Type, Type, bool> binding)
		{
			_binding = binding;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RegisterTypeToAllMatchStrategy"/> class.
		/// </summary>
		/// <param name="binding">The binding.</param>
		public RegisterTypeToAllMatchStrategy(Func<Type, bool> binding)
			: this((foundInterface, type) => binding.Invoke(foundInterface))
		{
		}

		/// <summary>
		/// Registers the specified type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="locator">The locator.</param>
		public void Register(Type type, IServiceLocator locator)
		{
			var interfaces = type.FindInterfaces((t, obj) => _binding.Invoke(t, type), null);
			foreach (var iFace in interfaces)
			{
				Register(iFace, type, locator);
			}
		}
	}
}