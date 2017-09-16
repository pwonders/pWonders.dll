using System.Collections.Generic;

namespace pWonders
{
	public static class IDictionaryExtension
	{
		public static void Set<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, TValue value)
		{
			if (instance.ContainsKey(key))
			{
				instance[key] = value;
			}
			else
			{
				instance.Add(key, value);
			}
		}

		public static bool Get<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, bool defaultValue)
		{
			TValue value;
			if (instance.TryGetValue(key, out value))
			{
				bool typed_value;
				if (bool.TryParse(value.ToString(), out typed_value))
				{
					return typed_value;
				}
			}
			return defaultValue;
		}

		public static int Get<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, int defaultValue)
		{
			TValue value;
			if (instance.TryGetValue(key, out value))
			{
				int typed_value;
				if (int.TryParse(value.ToString(), out typed_value))
				{
					return typed_value;
				}
			}
			return defaultValue;
		}

		public static string Get<TKey, TValue>(this IDictionary<TKey, TValue> instance, TKey key, string defaultValue)
		{
			TValue value;
			if (instance.TryGetValue(key, out value))
			{
				return value.ToString();
			}
			return defaultValue;
		}
	}
}
