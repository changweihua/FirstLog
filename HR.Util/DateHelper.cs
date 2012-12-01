using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR.Util
{
    /*************************************************************************************
     * CLR 版本:       4.0.30319.269
     * 类 名 称:       DateHelper
     * 机器名称:       HSERVER
     * 命名空间:       HR.Util
     * 文 件 名:       DateHelper
     * 创建时间:       2012/10/12 21:18:15
     * 作    者:       常伟华 Changweihua
     * 签    名:       To be or not, it is not a problem !
     * 网    站:       http://www.cmono.net
     * 邮    箱:       changweihua@outlook.com
     * 
     * 修改时间:
     * 修 改 人:
     * 
     ************************************************************************************/
    /// <summary>
    /// 添加类描述
    /// </summary>
    class DateHelper
    {
        /// <summary>
        /// 获取指定年份的最大周数
        /// </summary>
        /// <param name="year">年份</param>
        /// <returns>周数</returns>
        public static int GetMaxWeekOfYear(int year)
        {
            DateTime tempDate = new DateTime(year, 12, 31);
            int tempDayOfWeek = (int)tempDate.DayOfWeek;
            if (tempDayOfWeek != 0)
            {
                tempDate = tempDate.Date.AddDays(-tempDayOfWeek);
            }
            return GetWeekIndex(tempDate);
        }


        /// <summary>
        /// 获取当前日期是一年中的第几周，如果12月31号与下一年的1月1好在同一个星期则算下一年的第一周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetWeekIndex(DateTime dt)
        {
            //确定此时间在一年中的位置
            int dayOfYear = dt.DayOfYear;

            //当年第一天
            DateTime tempDate = new DateTime(dt.Year, 1, 1);

            //确定当年第一天
            int tempDayOfWeek = (int)tempDate.DayOfWeek;
            tempDayOfWeek = tempDayOfWeek == 0 ? 7 : tempDayOfWeek;
            //确定星期几
            int index = (int)dt.DayOfWeek;

            index = index == 0 ? 7 : index;

            //当前周的范围
            DateTime retStartDay = dt.AddDays(-(index - 1));
            DateTime retEndDay = dt.AddDays(7 - index);

            //确定当前是第几周
            int weekIndex = (int)Math.Ceiling(((double)dayOfYear + tempDayOfWeek - 1) / 7);

            if (retStartDay.Year < retEndDay.Year)
            {
                weekIndex = 1;
            }

            return weekIndex;
        }


        /// <summary>
        /// 获取指定年份第几周的日期范围
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="weekIndex">第n周</param>
        /// <returns></returns>
        public static bool GetWeekRange(int year, int weekIndex, out DateTime weekRangeStart, out DateTime weekRangeEnd)
        {

            if (weekIndex < 1)
            {
                throw new Exception("请输入大于0的整数");
            }

            int allDays = (weekIndex - 1) * 7;
            //确定当年第一天
            DateTime firstDate = new DateTime(year, 1, 1);
            int firstDayOfWeek = (int)firstDate.DayOfWeek;

            firstDayOfWeek = firstDayOfWeek == 0 ? 7 : firstDayOfWeek;

            //周开始日
            int startAddDays = allDays + (1 - firstDayOfWeek);
            weekRangeStart = firstDate.AddDays(startAddDays);
            //周结束日
            int endAddDays = allDays + (7 - firstDayOfWeek);
            weekRangeEnd = firstDate.AddDays(endAddDays);

            if (weekRangeStart.Year > year || (weekRangeStart.Year == year && weekRangeEnd.Year > year))
            {
                //throw new Exception("今年没有第" + weekIndex + "周。");
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 获取本周的周日周六的日期值
        /// </summary>
        /// <param name="date">当前日期</param>
        /// <param name="dtSun">周日</param>
        /// <param name="dtSat">周六</param>
        public static void GetWeekRange(DateTime date, out  DateTime dtSun, out   DateTime dtSat)
        {
            dtSun = System.DateTime.Now;
            dtSat = System.DateTime.Now;
            switch (date.DayOfWeek)
            {
                case System.DayOfWeek.Sunday:
                    dtSun = date;
                    dtSat = date.AddDays(6);
                    break;
                case System.DayOfWeek.Monday:
                    dtSun = date.AddDays(-1);
                    dtSat = date.AddDays(5);
                    break;

                case System.DayOfWeek.Tuesday:
                    dtSun = date.AddDays(-2);
                    dtSat = date.AddDays(4);
                    break;

                case System.DayOfWeek.Wednesday:
                    dtSun = date.AddDays(-3);
                    dtSat = date.AddDays(3);
                    break;

                case System.DayOfWeek.Thursday:
                    dtSun = date.AddDays(-4);
                    dtSat = date.AddDays(2);
                    break;

                case System.DayOfWeek.Friday:
                    dtSun = date.AddDays(-5);
                    dtSat = date.AddDays(1);
                    break;

                case System.DayOfWeek.Saturday:
                    dtSun = date.AddDays(-6);
                    dtSat = date;
                    break;
            }
        }


        /// <summary>
        /// 转换成星期中文汉字
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetWeekDayName(int index)
        {
            string result = string.Empty;
            switch (index)
            {
                case 0:
                    {
                        result = "星期日";
                        break;
                    }
                case 1:
                    {
                        result = "星期一";
                        break;
                    }
                case 2:
                    {
                        result = "星期二";
                        break;
                    }
                case 3:
                    {
                        result = "星期三";
                        break;
                    }
                case 4:
                    {
                        result = "星期四";
                        break;
                    }
                case 5:
                    {
                        result = "星期五";
                        break;
                    }
                case 6:
                    {
                        result = "星期六";
                        break;
                    }
            }

            return result;
        }


    }
}
