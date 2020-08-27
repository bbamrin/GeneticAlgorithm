using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurse.Model
{
	[Serializable]
	public class BitGene
	{
		private bool val;

		public BitGene(char v)
		{
			if (Char.GetNumericValue(v) == 0)
				val = false;
			else
				val = true;
		}
		public BitGene(bool v)
		{
			this.val = v;
		}
		public bool Value {
			get { return this.val;  }
			set { this.val = value; }
		}
	}
}
