using System;
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
			Console.OutputEncoding = Encoding.UTF8;
			// Kiểm tra ngẫu nhiên 1000 số
			int ntest = 1000;
			Random rn = new Random();
			for (int i = 0; i < ntest; i++)
			{
				ulong number = (ulong)rn.Next(1, 1000) * (ulong)rn.Next(1, Int32.MaxValue);
				if (number > 10000_000_000_000L)
					continue;

				var text = PriceToPriceString(number);
				var ntext = number.ToString("###,###,###,###,###");
				Console.WriteLine($"{ntext,20} --> {text}");
			}
		}

		private static string PriceToPriceString(ulong Price)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Price < 10000_000_000_000L)
			{
				ulong thousandBillions = Price / 1000_000_000_000L;
				ulong thousandBillionsRemainder = Price % 1000_000_000_000L;
				if (thousandBillions > 0)
				{
					stringBuilder.Append(_number_texts[thousandBillions] + " nghìn ");
				}
				
				ulong hundredBillions = thousandBillionsRemainder / 100_000_000_000L;
				ulong hundredBillionsRemainder = thousandBillionsRemainder % 100_000_000_000L;
				if (stringBuilder.Length > 0 || hundredBillions > 0)
				{
					stringBuilder.Append(_number_texts[hundredBillions] + " trăm ");
				}

				var tenBillions = hundredBillionsRemainder / 10_000_000_000L;
				var tenBillionsRemainder = hundredBillionsRemainder % 10_000_000_000L;
				if (stringBuilder.Length > 0)
				{
					if (tenBillions > 1)
					{
						stringBuilder.Append(_number_texts[tenBillions] + " mươi ");
					}
					else if (tenBillions == 1)
					{
						stringBuilder.Append(" mười ");
					}
				}

				var billions = tenBillionsRemainder / 1_000_000_000L;
				var billionsRemainder = tenBillionsRemainder % 1_000_000_000L;
				if (billions > 0)
				{
					stringBuilder.Append(_number_texts[billions]);
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(" tỉ ");
				}
				////////////////////////////////////////////////////////////////////////
				var hundredMillions = billionsRemainder / 100_000_000L;
				var hundredMillionsRemainder = billionsRemainder % 100_000_000L;
				if (stringBuilder.Length > 0 || hundredMillions > 0)
				{
					stringBuilder.Append(_number_texts[hundredMillions] + " trăm ");
				}

				var tenMillions = hundredMillionsRemainder / 10_000_000L;
				var tenMillionsRemainder = hundredMillionsRemainder % 10_000_000L;
				if (tenMillions == 1)
				{
					stringBuilder.Append(" mười ");
				}
				else if (tenMillions > 1)
				{
					stringBuilder.Append(_number_texts[tenMillions] + " mươi ");
				}
				
				var millions = tenMillionsRemainder / 1_000_000L;
				var millionsRemainder = tenMillionsRemainder % 1_000_000L;
				if (millions > 0)
				{
					stringBuilder.Append(_number_texts[millions]);
				}
				if (hundredMillions > 0 || tenMillions > 0 || millions > 0)
				{
					stringBuilder.Append(" triệu ");
				}
				/////////////////////////////////////////////////////////////////////////
				var hundredThousands = millionsRemainder / 100_000L;
				var hundredThousandsRemainder = millionsRemainder % 100_000L;
				if (stringBuilder.Length > 0 || hundredThousands > 0)
				{
					stringBuilder.Append(_number_texts[hundredThousands] + " trăm ");
				}

				var tenThousands = hundredThousandsRemainder / 10_000L;
				var tenThousandsRemainder = hundredThousandsRemainder % 10_000L;
				if (tenThousands > 1)
				{
					stringBuilder.Append(_number_texts[tenThousands] + " mươi ");
				}
				else if (tenThousands == 1)
				{
					stringBuilder.Append(" mười ");
				}
				else if (tenThousands == 0 && stringBuilder.Length > 0)
				{
					stringBuilder.Append(_number_texts[tenThousands] + " ");
				}
				
				var thousands = tenThousandsRemainder / 1_000L;
				var thousandsRemainder = tenThousandsRemainder % 1_000L;
				if (thousands > 0)
				{
					stringBuilder.Append(_number_texts[thousands]);
				}

				if (hundredThousands > 0 || tenThousands > 0 || thousands > 0)
				{
					stringBuilder.Append(" nghìn ");
				}
				///////////////////////////////////////////////////////////////////////////
				var hundreds = thousandsRemainder / 100L;
				var hundredsRemainder = thousandsRemainder % 100L;
				var tens = hundredsRemainder / 10L;
				var tensRemainder = hundredsRemainder % 10L;
				var unit = tensRemainder;

				if (hundreds > 0 || tens > 0 || unit > 0)
				{
					stringBuilder.Append(_number_texts[hundreds] + " trăm ");
				}

				if (tens > 1)
				{
					stringBuilder.Append(_number_texts[tens] + " mươi ");
				}
				else if (tens == 0)
				{
					stringBuilder.Append(_number_texts[tens] + " ");
				}
				else if (tens == 1)
				{
					stringBuilder.Append(" mười ");
				}	
				
				if (unit > 0)
				{
					stringBuilder.Append(_number_texts[unit]);
				}
				stringBuilder.Append(" đồng");

				return stringBuilder.ToString();
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}