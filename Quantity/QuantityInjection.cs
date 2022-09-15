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
			FieldInfo _quantities = typeof(GenericTypes).GetField("quantities", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
			Type[] quantities = (Type[])_quantities.GetValue(typeof(GenericTypes));
			quantities.Append(typeof(DataStorage));
		}

		public static void LogCurrentUnitTypes() {
			FieldInfo _unitCache = typeof(QuantityX.QuantityX).GetField("unitCache", BindingFlags.NonPublic | BindingFlags.Static);
			FieldInfo _unitNameCache = typeof(QuantityX.QuantityX).GetField("unitNameCache", BindingFlags.NonPublic | BindingFlags.Static);
			//Dictionary<Type, List<IUnit>> unitCache = (Dictionary<Type, List<IUnit>>)_unitCache.GetValue(typeof(QuantityX.QuantityX));
			Dictionary<Type, Dictionary<string, IUnit>> unitNameCache = (Dictionary<Type, Dictionary<string, IUnit>>)_unitNameCache.GetValue(typeof(QuantityX.QuantityX));

			UniLog.Log($"unitNameCache: {unitNameCache}");
			foreach (var kvp in unitNameCache) {
				UniLog.Log($"Key = {kvp.Key}, Value = {kvp.Value}");
				foreach (var kvb in kvp.Value) {
					UniLog.Log($"Key = {kvb.Key}, Value = {kvb.Value}");
				}
			}
		}

		//Adds new unit into _unitCache and _unitNameCache, at the moment, hardcoded DataStorage
		//Later just recheck GenericTypes for new types?
		public static void AppendUnitCache() {
			FieldInfo _unitCache = typeof(QuantityX.QuantityX).GetField("unitCache", BindingFlags.NonPublic | BindingFlags.Static);
			FieldInfo _unitNameCache = typeof(QuantityX.QuantityX).GetField("unitNameCache", BindingFlags.NonPublic | BindingFlags.Static);

			Dictionary<Type, List<IUnit>> unitCache = (Dictionary<Type, List<IUnit>>)_unitCache.GetValue(typeof(QuantityX.QuantityX));
			Dictionary<Type, Dictionary<string, IUnit>> unitNameCache = (Dictionary<Type, Dictionary<string, IUnit>>)_unitNameCache.GetValue(typeof(QuantityX.QuantityX));

			foreach (Type type in typeof(DataStorage).Assembly.GetTypes()) {
				if (typeof(IQuantity).IsAssignableFrom(type) && type.IsValueType) {
					IQuantity quantity = (IQuantity)Activator.CreateInstance(type);
					List<IUnit> list = new List<IUnit>();
					unitCache.Add(type, list);
					bool flag = false;
					foreach (Type type2 in type.GetInterfaces()) {
						if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(IQuantitySI<>)) {
							flag = true;
							break;
						}
					}
					BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.Public;
					List<FieldInfo[]> list2 = new List<FieldInfo[]>();
					list2.Add(type.GetFields(bindingFlags));
					if (flag) {
						IQuantitySI quantitySI = (IQuantitySI)quantity;
						foreach (IUnit unit in quantitySI.GetCommonSIUnits()) {
							UnitGroup.Common.RegisterUnit(unit);
							UnitGroup.CommonMetric.RegisterUnit(unit);
						}
						foreach (IUnit unit2 in quantitySI.GetExludedSIUnits()) {
							UnitGroup.Metric.RemoveUnit(unit2);
						}
						Type type3 = typeof(SI<>).MakeGenericType(new Type[] { type });
						list2.Add(type3.GetFields(bindingFlags));
					}
					foreach (FieldInfo[] array2 in list2) {
						foreach (FieldInfo fieldInfo in array2) {
							if (typeof(IUnit).IsAssignableFrom(fieldInfo.FieldType)) {
								list.Add((IUnit)fieldInfo.GetValue(null));
							}
						}
					}
					list.Sort();
					Dictionary<string, IUnit> dictionary = new Dictionary<string, IUnit>();
					unitNameCache.Add(type, dictionary);
					foreach (IUnit unit3 in list) {
						foreach (string text in unit3.GetUnitNames()) {
							if (!dictionary.ContainsKey(text)) {
								dictionary.Add(text.Trim(), unit3);
							} else {
								UniLog.Log($"{text} has been already added");
							}
						}
					}
				}
			}

		}
	}
}
