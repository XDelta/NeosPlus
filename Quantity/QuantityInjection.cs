using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BaseX;

using FrooxEngine;

using QuantityX;

namespace NEOSPlus.Quantity {
	internal class QuantityInjection {
		public static void AppendTypes() {
			UniLog.Log($"Attempting to append additional Quantity Types");
			FieldInfo[] fields = typeof(GenericTypes).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
			foreach (FieldInfo field in fields) {
				UniLog.Log(field);
			}

			FieldInfo fi = typeof(GenericTypes).GetField("quantities", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
			UniLog.Log($"quantities: {fi}");
			Type[] test = (Type[])fi.GetValue(typeof(GenericTypes));
			/*Type[] types = new Type[] {
				typeof(Quantity.DataStorage)
			};*/
			
			UniLog.Log($"DataStorage field: {test.ToString()}");
			test.Append(typeof(DataStorage));

			FieldInfo unitCache = typeof(QuantityX.QuantityX).GetField("unitNameCache", BindingFlags.NonPublic | BindingFlags.Static);
			
			Dictionary<Type, Dictionary<string, IUnit>> a = (Dictionary<Type, Dictionary<string, IUnit>>)unitCache.GetValue(typeof(QuantityX.QuantityX));
			UniLog.Log($"Dict: {a}");

			//Dictionary<string, IUnit> dictionary = new Dictionary<string, IUnit>();
			//a.Add(typeof(DataStorage), dictionary);
			

			//QuantityX.QuantityX.unit
		}
	}
}
