﻿using System;
using System.Text;

namespace NumberToVietnameseString
{
	class Program
	{
		private static readonly string[] _number_texts = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
		//private static readonly string[] _number_units = new string[] { "chục", "trăm", "nghìn", "triệu", "tỉ" };
		//private static readonly string[] _place_texts = new string[] { "chục", "trăm", "nghìn", "chục nghìn", "trăm nghìn", "triệu", "chục triệu", "trăm triệu", "tỉ", "chục tỉ", "trăm tỉ", "nghìn tỉ" };

		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			// Kiểm tra ngẫu nhiên 1000 số
			int ntest = 1000;
			Random rn = new Random();
			for (int i = 0; i < ntest; i++)
			{
				ulong number = (ulong)(rn.NextDouble() * rn.Next(1, Int32.MaxValue));
				var text = PriceToPriceString(number);
				var ntext = number.ToString("###,###,###,###,###");
				Console.WriteLine($"{ntext,20} --> {text}");
			}
		}

		private static string PriceToPriceString(ulong Price)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Price < 1000_000_000_000L)
			{
				ulong thousandBillions = Price / 1000_000_000_000L;
				ulong thousandBillionsRemainder = Price % 1000_000_000_000L;
				if (thousandBillions > 0)
				{
					stringBuilder.Append(_number_texts[thousandBillions] + " nghìn ");
				}
				ulong hundredBillions = thousandBillionsRemainder / 100_000_000_000L;
				ulong hundredBillionsRemainder = thousandBillionsRemainder % 100_000_000_000L;
				if (hundredBillions > 0)
				{
					stringBuilder.Append(_number_texts[hundredBillions] + " trăm ");
				}
				var tenBillions = hundredBillionsRemainder / 10_000_000_000L;
				var tenBillionsRemainder = hundredBillionsRemainder % 10_000_000_000L;
				if (tenBillions > 0)
				{
					stringBuilder.Append(_number_texts[tenBillions] + " mươi ");
				}
				var billions = tenBillionsRemainder / 1_000_000_000L;
				var billionsRemainder = tenBillionsRemainder % 1_000_000_000L;
				if (billions > 0)
				{
					stringBuilder.Append(_number_texts[billions] + " tỉ ");
				}

				var hundredMillions = billionsRemainder / 100_000_000L;
				var hundredMillionsRemainder = billionsRemainder % 100_000_000L;
				if (hundredBillions > 0)
				{
					stringBuilder.Append(_number_texts[hundredMillions] + " trăm ");
				}
				var tenMillions = hundredMillionsRemainder / 10_000_000L;
				var tenMillionsRemainder = hundredMillionsRemainder % 10_000_000L;
				if (tenBillions > 0)
				{
					stringBuilder.Append(_number_texts[tenMillions] + " mươi ");
				}
				var millions = tenMillionsRemainder / 1_000_000L;
				var millionsRemainder = tenMillionsRemainder % 1_000_000L;
				if (millions > 0)
				{
					stringBuilder.Append(_number_texts[millions] + " triệu ");
				}

				var hundredThousands = millionsRemainder / 100_000L;
				var hundredThousandsRemainder = millionsRemainder % 100_000L;
				if (hundredThousands > 0)
				{
					stringBuilder.Append(_number_texts[hundredThousands] + " trăm ");
				}
				var tenThousands = hundredThousandsRemainder / 10_000L;
				var tenThousandsRemainder = hundredThousandsRemainder % 10_000L;
				if (tenThousands > 0)
				{
					stringBuilder.Append(_number_texts[tenThousands] + " mươi ");
				}
				var thousands = tenThousandsRemainder / 1_000L;
				var thousandsRemainder = tenThousandsRemainder % 1_000L;
				if (thousands > 0)
				{
					stringBuilder.Append(_number_texts[thousands] + " nghìn ");
				}

				var hundreds = thousandsRemainder / 100L;
				var hundredsRemainder = thousandsRemainder % 100L;
				if (hundreds > 0)
				{
					stringBuilder.Append(_number_texts[hundreds] + " trăm ");
				}
				var tens = hundredsRemainder / 10L;
				var tensRemainder = hundredsRemainder % 10L;
				if (tens > 0)
				{
					stringBuilder.Append(_number_texts[tens] + " mươi ");
				}
				var unit = tensRemainder % 1L;
				if (tens > 0)
				{
					stringBuilder.Append(_number_texts[tens] + " đồng ");
				}
				return stringBuilder.ToString();
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}