using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuantityX;

namespace QuantityX {
	public readonly struct DataStorage : IQuantity<DataStorage>, IQuantity, IComparable<DataStorage>, IEquatable<DataStorage> {
		double IQuantity.BaseValue {
			get {
				return this.BaseValue;
			}
		}

		public DataStorage(double baseValue = 0.0) {
			this = default(DataStorage);
			this.BaseValue = baseValue;
		}

		public bool Equals(DataStorage other) {
			return this.BaseValue == other.BaseValue;
		}

		public int CompareTo(DataStorage other) {
			return this.BaseValue.CompareTo(other.BaseValue);
		}

		public string[] GetShortBaseNames() {
			return new string[] { "" };
		}

		public string[] GetLongBaseNames() {
			return new string[] { "" };
		}

		public Unit<DataStorage> DefaultUnit {
			get {
				return DataStorage.Byte;
			}
		}

		public DataStorage New(double baseVal) {
			return new DataStorage(baseVal);
		}

		public DataStorage Add(DataStorage q) {
			return new DataStorage(this.BaseValue + q.BaseValue);
		}

		public DataStorage Subtract(DataStorage q) {
			return new DataStorage(this.BaseValue - q.BaseValue);
		}

		public DataStorage Multiply(double n) {
			return new DataStorage(this.BaseValue * n);
		}

		public DataStorage Multiply(DataStorage a, Ratio r) {
			return a * r.BaseValue;
		}

		public DataStorage Multiply(Ratio r, DataStorage a) {
			return a * r.BaseValue;
		}

		public DataStorage Divide(double n) {
			return new DataStorage(this.BaseValue / n);
		}

		public Ratio Divide(DataStorage q) {
			return new Ratio(this.BaseValue / q.BaseValue);
		}

		public static DataStorage Parse(string str, Unit<DataStorage> defaultUnit = null) {
			return Unit<DataStorage>.Parse(str, defaultUnit);
		}

		public static bool TryParse(string str, out DataStorage q, Unit<DataStorage> defaultUnit = null) {
			return Unit<DataStorage>.TryParse(str, out q, defaultUnit);
		}

		public static DataStorage operator +(DataStorage a, DataStorage b) {
			return a.Add(b);
		}

		public static DataStorage operator -(DataStorage a, DataStorage b) {
			return a.Subtract(b);
		}

		public static DataStorage operator *(DataStorage a, double n) {
			return a.Multiply(n);
		}

		public static DataStorage operator /(DataStorage a, double n) {
			return a.Divide(n);
		}

		public static Ratio operator /(DataStorage a, DataStorage b) {
			return a.Divide(b);
		}

		public static DataStorage operator -(DataStorage a) {
			return a.Multiply(-1.0);
		}

		public override string ToString() {
			return this.FormatAuto();
		}

		public readonly double BaseValue;

		public static readonly Unit<DataStorage> Bit = new Unit<DataStorage>(1, new UnitGroup[] { UnitGroup.Common }, new string[] { " b" }, new string[] { " bits", " bit" });

		public static readonly Unit<DataStorage> Byte = new Unit<DataStorage>(8, new UnitGroup[] { UnitGroup.Common }, new string[] { " B" }, new string[] { " bytes", " byte" });

		public static readonly Unit<DataStorage> Kilobyte = new Unit<DataStorage>(1000 * Byte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " KB" }, new string[] { " kilobytes", " kilobyte" });

		public static readonly Unit<DataStorage> Megabyte = new Unit<DataStorage>(1000 * Kilobyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " MB" }, new string[] { " megabytes", " megabyte" });

		public static readonly Unit<DataStorage> Gigabyte = new Unit<DataStorage>(1000 * Megabyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " GB" }, new string[] { " gigabytes", " gigabyte" });

		public static readonly Unit<DataStorage> Terabyte = new Unit<DataStorage>(1000 * Gigabyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " TB" }, new string[] { " terabytes", " terabyte" });

		public static readonly Unit<DataStorage> Petabyte = new Unit<DataStorage>(1000 * Terabyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " PB" }, new string[] { " petabytes", " petabyte" });

		public static readonly Unit<DataStorage> Exabyte = new Unit<DataStorage>(1000 * Petabyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " EB" }, new string[] { " exabytes", " exabyte" });

		public static readonly Unit<DataStorage> Zettabyte = new Unit<DataStorage>(1000 * Exabyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " ZB" }, new string[] { " zettabytes", " zettabyte" });

		public static readonly Unit<DataStorage> Yottabyte = new Unit<DataStorage>(1000 * Zettabyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " YB" }, new string[] { " yottabytes", " yottabyte" });

		public static readonly Unit<DataStorage> Kibibyte = new Unit<DataStorage>(1024 * Byte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " KiB" }, new string[] { " kibibytes", " kibibyte" });

		public static readonly Unit<DataStorage> Mebibyte = new Unit<DataStorage>(1024 * Kibibyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " MiB" }, new string[] { " mebibytes", " mebibyte" });

		public static readonly Unit<DataStorage> Gibibyte = new Unit<DataStorage>(1024 * Mebibyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " GiB" }, new string[] { " kibibytes", " kibibyte" });

		public static readonly Unit<DataStorage> Tebibyte = new Unit<DataStorage>(1024 * Gibibyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " TiB" }, new string[] { " tebibytes", " tebibyte" });

		public static readonly Unit<DataStorage> Pebibyte = new Unit<DataStorage>(1024 * Tebibyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " PiB" }, new string[] { " pebibytes", " pebibyte" });

		public static readonly Unit<DataStorage> Exbibyte = new Unit<DataStorage>(1024 * Pebibyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " EiB" }, new string[] { " exbiytes", " exbibyte" });

		public static readonly Unit<DataStorage> Zebibyte = new Unit<DataStorage>(1024 * Exbibyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " ZiB" }, new string[] { " zebibytes", " zebibyte" });

		public static readonly Unit<DataStorage> Yobibyte = new Unit<DataStorage>(1024 * Zebibyte.Ratio, new UnitGroup[] { UnitGroup.Common }, new string[] { " YiB" }, new string[] { " yobiytes", " yobibyte" });

	}
}
