using System;
using System.Collections.Generic;

namespace MasterQ
{
	public static class Initial
	{
		public static void init()
		{
			MSearch.provinces = getAllProvinces();
		}

		public static List<Province> getAllProvinces()
		{
			List<Province> ret = new List<Province>();
			List<String[]> listProv = new List<String[]>();
			listProv.Add(new String[] { "Bangkok", "BangKhen", "Chatuchak" });
			listProv.Add(new String[] { "ChiangMai", "Muang", "HangDong" });
			listProv.Add(new String[] { "Phrae", "MuangPhrae", "Long" });

			String[] temp;
			Province province;
			for (int j = 0; j < listProv.ToArray().Length; j++)
			{
				temp = listProv.ToArray()[j];
				province = new Province();
				province.name = temp[0];
				for (int i = 1; i < temp.Length; i++)
				{
					province.districts.Add(temp[i]);
				}
				ret.Add(province);
			}

			return ret;
		}
	}
}
