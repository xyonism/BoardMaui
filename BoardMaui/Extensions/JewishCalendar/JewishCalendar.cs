using BoardMaui.Extensions.JewishCalendar;

namespace Zmanim.JewishCalendar
{

    public partial class JewishCalendar
    {
        /// <summary>
        /// Normalizes the months as 1-13 (1-12, with 13 being adar bet)
        /// This is different than the native HebrewCalendar month index 
        /// which changes the index of several months depending on whether or not it is a leap year
        /// see: https://msdn.microsoft.com/en-us/library/system.globalization.hebrewcalendar(v=vs.110).aspx
        /// </summary>
        public enum JewishMonth
        {
            /// <summary>
            /// To represent "no month"
            /// </summary>
            NONE = -1,
            /// <summary>
            /// Value of the month field indicating Nissan, the first numeric month of the year in the Jewish calendar. With the
            /// year starting at <seealso cref="TISHREI"/>, it would actually be the 7th (or 8th in a {@link #IsLeapYearFromDateTime leap
            /// year}) month of the year.
            /// </summary>
            NISSAN = 1,
            /// <summary>
            /// Value of the month field indicating Iyar, the second numeric month of the year in the Jewish calendar. With the
            /// year starting at <seealso cref="TISHREI"/>, it would actually be the 8th (or 9th in a {@link #IsLeapYearFromDateTime leap
            /// year}) month of the year.
            /// </summary>
            IYAR,
            /// <summary>
            /// Value of the month field indicating Sivan, the third numeric month of the year in the Jewish calendar. With the
            /// year starting at <seealso cref="TISHREI"/>, it would actually be the 9th (or 10th in a {@link #IsLeapYearFromDateTime leap
            /// year}) month of the year.
            /// </summary>
            SIVAN,
            /// <summary>
            /// Value of the month field indicating Tammuz, the fourth numeric month of the year in the Jewish calendar. With the
            /// year starting at <seealso cref="TISHREI"/>, it would actually be the 10th (or 11th in a {@link #IsLeapYearFromDateTime leap
            /// year}) month of the year.
            /// </summary>
            TAMMUZ,
            /// <summary>
            /// Value of the month field indicating Av, the fifth numeric month of the year in the Jewish calendar. With the year
            /// starting at <seealso cref="TISHREI"/>, it would actually be the 11th (or 12th in a <seealso cref="IsLeapYearFromDateTime"/>)
            /// month of the year.
            /// </summary>
            AV,
            /// <summary>
            /// Value of the month field indicating Elul, the sixth numeric month of the year in the Jewish calendar. With the
            /// year starting at <seealso cref="TISHREI"/>, it would actually be the 12th (or 13th in a {@link #IsLeapYearFromDateTime leap
            /// year}) month of the year.
            /// </summary>
            ELUL,
            /// <summary>
            /// Value of the month field indicating Tishrei, the seventh numeric month of the year in the Jewish calendar. With
            /// the year starting at this month, it would actually be the 1st month of the year.
            /// </summary>
            TISHREI,
            /// <summary>
            /// Value of the month field indicating Cheshvan/marcheshvan, the eighth numeric month of the year in the Jewish
            /// calendar. With the year starting at <seealso cref="TISHREI"/>, it would actually be the 2nd month of the year.
            /// </summary>
            CHESHVAN,
            /// <summary>
            /// Value of the month field indicating Kislev, the ninth numeric month of the year in the Jewish calendar. With the
            /// year starting at <seealso cref="TISHREI"/>, it would actually be the 3rd month of the year.
            /// </summary>
            KISLEV,
            /// <summary>
            /// Value of the month field indicating Teves, the tenth numeric month of the year in the Jewish calendar. With the
            /// year starting at <seealso cref="TISHREI"/>, it would actually be the 4th month of the year.
            /// </summary>
            TEVES,
            /// <summary>
            /// Value of the month field indicating Shevat, the eleventh numeric month of the year in the Jewish calendar. With
            /// the year starting at <seealso cref="TISHREI"/>, it would actually be the 5th month of the year.
            /// </summary>
            SHEVAT,
            /// <summary>
            /// Value of the month field indicating Adar (or Adar I in a <seealso cref="IsLeapYearFromDateTime"/>), the twelfth
            /// numeric month of the year in the Jewish calendar. With the year starting at <seealso cref="TISHREI"/>, it would actually
            /// be the 6th month of the year.
            /// </summary>
            ADAR,
            /// <summary>
            /// Value of the month field indicating Adar II, the leap (intercalary or embolismic) thirteenth (Undecimber) numeric
            /// month of the year added in Jewish <seealso cref="IsLeapYearFromDateTime"/>). The leap years are years 3, 6, 8, 11,
            /// 14, 17 and 19 of a 19 year cycle. With the year starting at <seealso cref="TISHREI"/>, it would actually be the 7th month
            /// of the year.
            /// </summary>
            ADAR_II
        }

        /// <summary>
        /// Jewish holiday.
        /// </summary>
        public enum JewishHoliday
        {
            אין = -1,
            ערב_פסח = 0,
            פסח = 1,
            חול_המועד_פסח = 2,
            פסח_שני = 3,
            ערב_שבועות = 4,
            שבועות = 5,
            שבעה_עשר_בתמוז = 6,
            תשעה_באב = 7,
            טו_באב = 8,
            ערב_ראש_השנה = 9,
            ראש_השנה = 10,
            צום_גדליה = 11,
            ערב_יום_כיפור = 12,
            יום_כיפור = 13,
            ערב_סוכות = 14,
            סוכות = 15,
            חול_המועד_סוכות = 16,
            הושענא_רבה = 17,
            שמיני_עצרת = 18,
            שמחת_תורה = 19,
            חנוכה = 21,
            עשירי_בטבת = 22,
            טו_בשבט = 23,
            צום_אסתר = 24,
            פורים = 25,
            שושן_פורים = 26,
            פורים_קטן = 27,
            יום_השואה = 29,
            יום_הזיכרון = 30,
            יום_העצמאות = 31,
            יום_ירושלים = 32
        }

        public enum JewishYearType
        {
            /// <summary>
            /// A short year where both <seealso cref="CHESHVAN"/> and <seealso cref="KISLEV"/> are 29 days.
            /// </summary>
            /// <seealso cref="GetCheshvanKislevKviah()"></seealso>
            /// <seealso cref="HebrewDateFormatter.GetFormattedKviah(int)"></seealso>
            CHASERIM = 0,

            /// <summary>
            /// An ordered year where <seealso cref="CHESHVAN"/> is 29 days and <seealso cref="KISLEV"/> is 30 days.
            /// </summary>
            /// <seealso cref="GetCheshvanKislevKviah()"></seealso>
            /// <seealso cref="HebrewDateFormatter.GetFormattedKviah(int)"></seealso>
            KESIDRAN,

            /// <summary>
            /// A long year where both <seealso cref="CHESHVAN"/> and <seealso cref="KISLEV"/> are 30 days.
            /// </summary>
            /// <seealso cref="HebrewDateFormatter.v()"></seealso>
            /// <seealso cref="HebrewDateFormatter.GetFormattedKviah(int)"></seealso>
            SHELAIMIM
        }

        /// <summary>
        /// Parshiyos 
        /// </summary>
        public enum Parsha
        {
            NONE,
            BERESHIS,
            NOACH,
            LECH_LECHA,
            VAYERA,
            CHAYEI_SARA,
            TOLDOS,
            VAYETZEI,
            VAYISHLACH,
            VAYESHEV,
            MIKETZ,
            VAYIGASH,
            VAYECHI,
            SHEMOS,
            VAERA,
            BO,
            BESHALACH,
            YISRO,
            MISHPATIM,
            TERUMAH,
            TETZAVEH,
            KI_SISA,
            VAYAKHEL,
            PEKUDEI,
            VAYIKRA,
            TZAV,
            SHMINI,
            TAZRIA,
            METZORA,
            ACHREI_MOS,
            KEDOSHIM,
            EMOR,
            BEHAR,
            BECHUKOSAI,
            BAMIDBAR,
            NASSO,
            BEHAALOSCHA,
            SHLACH,
            KORACH,
            CHUKAS,
            BALAK,
            PINCHAS,
            MATOS,
            MASEI,
            DEVARIM,
            VAESCHANAN,
            EIKEV,
            REEH,
            SHOFTIM,
            KI_SEITZEI,
            KI_SAVO,
            NITZAVIM,
            VAYEILECH,
            HAAZINU,
            VZOS_HABERACHA,
            VAYAKHEL_PEKUDEI,
            TAZRIA_METZORA,
            ACHREI_MOS_KEDOSHIM,
            BEHAR_BECHUKOSAI,
            CHUKAS_BALAK,
            MATOS_MASEI,
            NITZAVIM_VAYEILECH,
            שקלים,
            ZACHOR,
            PARA,
            HACHODESH
        }

        /// <summary>
        /// Natives the month to jewish month.
        /// see https://msdn.microsoft.com/en-us/library/system.globalization.hebrewcalendar(v=vs.110).aspx
        /// </summary>
        /// <returns>The month to jewish month.</returns>
        /// <param name="nativeMonth">Native month.</param>
        /// <param name="leapYear">If set to <c>true</c> leap year.</param>
        public JewishMonth NativeMonthToJewishMonth(int nativeMonth, bool leapYear)
        {

            switch (nativeMonth)
            {
                case 1:
                    return JewishMonth.TISHREI;
                case 2:
                    return JewishMonth.CHESHVAN;
                case 3:
                    return JewishMonth.KISLEV;
                case 4:
                    return JewishMonth.TEVES;
                case 5:
                    return JewishMonth.SHEVAT;
            }

            if (leapYear)
            {
                switch (nativeMonth)
                {
                    case 6:
                        return JewishMonth.ADAR;
                    case 7:
                        return JewishMonth.ADAR_II;
                    case 8:
                        return JewishMonth.NISSAN;
                    case 9:
                        return JewishMonth.IYAR;
                    case 10:
                        return JewishMonth.SIVAN;
                    case 11:
                        return JewishMonth.TAMMUZ;
                    case 12:
                        return JewishMonth.AV;
                    case 13:
                        return JewishMonth.ELUL;
                }
            }
            else
            {
                switch (nativeMonth)
                {
                    case 6:
                        return JewishMonth.ADAR;
                    case 7:
                        return JewishMonth.NISSAN;
                    case 8:
                        return JewishMonth.IYAR;
                    case 9:
                        return JewishMonth.SIVAN;
                    case 10:
                        return JewishMonth.TAMMUZ;
                    case 11:
                        return JewishMonth.AV;
                    case 12:
                        return JewishMonth.ELUL;
                }
            }

            return JewishMonth.NONE;
        }


        /// <summary>
        /// Jewishs the month to native month.
        /// see https://msdn.microsoft.com/en-us/library/system.globalization.hebrewcalendar(v=vs.110).aspx
        /// </summary>
        /// <returns>The month to native month.</returns>
        /// <param name="jewishMonth">Jewish month.</param>
        /// <param name="leapYear">If set to <c>true</c> leap year.</param>
        public int JewishMonthToNativeMonth(JewishMonth jewishMonth, bool leapYear)
        {
            switch (jewishMonth)
            {
                case JewishMonth.TISHREI:
                    return 1;
                case JewishMonth.CHESHVAN:
                    return 2;
                case JewishMonth.KISLEV:
                    return 3;
                case JewishMonth.TEVES:
                    return 4;
                case JewishMonth.SHEVAT:
                    return 5;
            }

            if (leapYear)
            {
                switch (jewishMonth)
                {
                    case JewishMonth.ADAR:
                        return 6;
                    case JewishMonth.ADAR_II:
                        return 7;
                    case JewishMonth.NISSAN:
                        return 8;
                    case JewishMonth.IYAR:
                        return 9;
                    case JewishMonth.SIVAN:
                        return 10;
                    case JewishMonth.TAMMUZ:
                        return 11;
                    case JewishMonth.AV:
                        return 12;
                    case JewishMonth.ELUL:
                        return 13;
                }
            }
            else
            {
                switch (jewishMonth)
                {
                    case JewishMonth.ADAR:
                        return 6;
                    case JewishMonth.NISSAN:
                        return 7;
                    case JewishMonth.IYAR:
                        return 8;
                    case JewishMonth.SIVAN:
                        return 9;
                    case JewishMonth.TAMMUZ:
                        return 10;
                    case JewishMonth.AV:
                        return 11;
                    case JewishMonth.ELUL:
                        return 12;
                }
            }

            return -1;
        }

        /// <summary>
        /// Returns the Daf Yomi (Bavli) for the date that the calendar is set to. See the
        /// <see cref="HebrewDateFormatter.FormatDafYomiBavli(Daf)"/> for the ability to format the daf in Hebrew or transliterated
        /// masechta names.
        /// </summary>
        /// <returns>the daf as a <see cref="Daf"/></returns>
        public Daf GetDafYomiBavli(DateTime dt)
        {
            return YomiCalculator.GetDafYomiBavli(dt);
        }

        /// <summary>
        /// Get the Day of week where 1 is Sunday ... and 7 is Shabbos
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int GetJewishDayOfWeek(DateTime dt) =>
#if NOHEBREWCALENDAR
            return (int)dt.DayOfWeek + 1;
#else
            (int)GetDayOfWeek(dt) + 1;
#endif


        /// <summary>
        /// Determines whether this instance is leap year from date time the specified dt.
        /// </summary>
        /// <returns><c>true</c> if this instance is leap year from date time the specified dt; otherwise, <c>false</c>.</returns>
        /// <param name="year">Jewish Year</param>
        public
#if !NOHEBREWCALENDAR
        override
#endif

            bool IsLeapYear(int year) =>
#if NOHEBREWCALENDAR
            return (((7 * (long)year + 1) % 19) < 7);
#else
            base.IsLeapYear(year);
#endif


#if NOHEBREWCALENDAR
        public 
#else
        private
#endif
        JewishHoliday GetJewishHoliday(int dayOfMonth, int dayOfWeek, int year,
            bool inIsrael, bool useModernHolidays, JewishMonth hebrewMonth,
            bool isAdar29Days)
        {
            switch (hebrewMonth)
            {
                case JewishMonth.NISSAN:
                    if (dayOfMonth == 14)
                    {
                        return JewishHoliday.ערב_פסח;
                    }
                    else if (dayOfMonth == 15 || dayOfMonth == 21
                                              || (!inIsrael && (dayOfMonth == 16 || dayOfMonth == 22)))
                    {
                        return JewishHoliday.פסח;
                    }
                    else if ((dayOfMonth >= 17 && dayOfMonth <= 20)
                             || (dayOfMonth == 16 && inIsrael))
                    {
                        return JewishHoliday.חול_המועד_פסח;
                    }

                    if (useModernHolidays
                        && ((dayOfMonth == 26 && dayOfWeek == 5)
                            || (dayOfMonth == 28 && dayOfWeek == 2)
                            || (dayOfMonth == 27 && dayOfWeek != 1 && dayOfWeek != 6)))
                    {
                        return JewishHoliday.יום_השואה;
                    }

                    break;
                case JewishMonth.IYAR:
                    if (useModernHolidays
                        && ((dayOfMonth == 4 && dayOfWeek == 3)
                            || ((dayOfMonth == 3 || dayOfMonth == 2) && dayOfWeek == 4) || (dayOfMonth == 5 && dayOfWeek == 2)))
                    {
                        return JewishHoliday.יום_הזיכרון;
                    }

                    // if 5 Iyar falls on Wed Yom Haatzmaut is that day. If it fal1s on Friday or Shabbos it is moved back to
                    // Thursday. If it falls on Monday it is moved to Tuesday
                    if (useModernHolidays
                        && ((dayOfMonth == 5 && dayOfWeek == 4)
                            || ((dayOfMonth == 4 || dayOfMonth == 3) && dayOfWeek == 5) || (dayOfMonth == 6 && dayOfWeek == 3)))
                    {
                        return JewishHoliday.יום_העצמאות;
                    }

                    if (dayOfMonth == 14)
                    {
                        return JewishHoliday.פסח_שני;
                    }

                    if (useModernHolidays && dayOfMonth == 28)
                    {
                        return JewishHoliday.יום_ירושלים;
                    }

                    break;
                case JewishMonth.SIVAN:
                    if (dayOfMonth == 5)
                    {
                        return JewishHoliday.ערב_שבועות;
                    }
                    else if (dayOfMonth == 6 || (dayOfMonth == 7 && !inIsrael))
                    {
                        return JewishHoliday.שבועות;
                    }

                    break;
                case JewishMonth.TAMMUZ:
                    // push off the fast day if it falls on Shabbos
                    if ((dayOfMonth == 17 && dayOfWeek != 7)
                        || (dayOfMonth == 18 && dayOfWeek == 1))
                    {
                        return JewishHoliday.שבעה_עשר_בתמוז;
                    }

                    break;
                case JewishMonth.AV:
                    // if Tisha B'av falls on Shabbos, push off until Sunday
                    if ((dayOfWeek == 1 && dayOfMonth == 10)
                        || (dayOfWeek != 7 && dayOfMonth == 9))
                    {
                        return JewishHoliday.תשעה_באב;
                    }
                    else if (dayOfMonth == 15)
                    {
                        return JewishHoliday.טו_באב;
                    }

                    break;
                case JewishMonth.ELUL:
                    if (dayOfMonth == 29)
                    {
                        return JewishHoliday.ערב_ראש_השנה;
                    }

                    break;
                case JewishMonth.TISHREI:
                    if (dayOfMonth is 1 or 2)
                    {
                        return JewishHoliday.ראש_השנה;
                    }
                    else if ((dayOfMonth == 3 && dayOfWeek != 7)
                             || (dayOfMonth == 4 && dayOfWeek == 1))
                    {
                        // push off Tzom Gedalia if it falls on Shabbos
                        return JewishHoliday.צום_גדליה;
                    }
                    else if (dayOfMonth == 9)
                    {
                        return JewishHoliday.ערב_יום_כיפור;
                    }
                    else if (dayOfMonth == 10)
                    {
                        return JewishHoliday.יום_כיפור;
                    }
                    else if (dayOfMonth == 14)
                    {
                        return JewishHoliday.ערב_סוכות;
                    }

                    if (dayOfMonth == 15 || (dayOfMonth == 16 && !inIsrael))
                    {
                        return JewishHoliday.סוכות;
                    }

                    if ((dayOfMonth >= 17 && dayOfMonth <= 20) || (dayOfMonth == 16 && inIsrael))
                    {
                        return JewishHoliday.חול_המועד_סוכות;
                    }

                    if (dayOfMonth == 21)
                    {
                        return JewishHoliday.הושענא_רבה;
                    }

                    if (dayOfMonth == 22)
                    {
                        //theoretically this could be simchat torah if in Israel, but shemini atzeret is really the yom tov
                        return JewishHoliday.שמיני_עצרת;
                    }

                    if (dayOfMonth == 23 && !inIsrael)
                    {
                        return JewishHoliday.שמחת_תורה;
                    }

                    break;
                case JewishMonth.KISLEV: // no yomtov in CHESHVAN
                                         // if (dayOfMonth == 24) {
                                         // return EREV_CHANUKAH;
                                         // } else
                    if (dayOfMonth >= 25)
                    {
                        return JewishHoliday.חנוכה;
                    }

                    break;
                case JewishMonth.TEVES:
                    if (dayOfMonth == 1 || dayOfMonth == 2
                                        || (dayOfMonth == 3 && isAdar29Days))
                    {
                        return JewishHoliday.חנוכה;
                    }
                    else if (dayOfMonth == 10)
                    {
                        return JewishHoliday.עשירי_בטבת;
                    }

                    break;
                case JewishMonth.SHEVAT:
                    if (dayOfMonth == 15)
                    {
                        return JewishHoliday.טו_בשבט;
                    }

                    break;
                case JewishMonth.ADAR:
                    if (!IsLeapYear(year))
                    {
                        // if 13th Adar falls on Friday or Shabbos, push back to Thursday
                        if (((dayOfMonth == 11 || dayOfMonth == 12) && dayOfWeek == 5)
                            || (dayOfMonth == 13 && !(dayOfWeek == 6 || dayOfWeek == 7)))
                        {
                            return JewishHoliday.צום_אסתר;
                        }

                        if (dayOfMonth == 14)
                        {
                            return JewishHoliday.פורים;
                        }
                        else if (dayOfMonth == 15 && inIsrael)
                        {
                            return JewishHoliday.שושן_פורים;
                        }
                    }
                    else
                    {
                        // else if a leap year
                        if (dayOfMonth == 14)
                        {
                            return JewishHoliday.פורים_קטן;
                        }
                    }

                    break;
                case JewishMonth.ADAR_II:
                    // if 13th Adar falls on Friday or Shabbos, push back to Thursday
                    if (((dayOfMonth == 11 || dayOfMonth == 12) && dayOfWeek == 5)
                        || (dayOfMonth == 13 && !(dayOfWeek == 6 || dayOfWeek == 7)))
                    {
                        return JewishHoliday.צום_אסתר;
                    }

                    if (dayOfMonth == 14)
                    {
                        return JewishHoliday.פורים;
                    }
                    else if (dayOfMonth == 15 && inIsrael)
                    {
                        return JewishHoliday.שושן_פורים;
                    }

                    break;
            }

            // if we get to this stage, then there are no holidays for the given date return -1
            return JewishHoliday.אין;
        }


        /// <summary>
        /// This method will return false for a non Yom Tov day, even if it is Shabbos.
        /// </summary>
        /// <returns>if the Yom Tov day has a melacha (work)  prohibition.</returns>
#if NOHEBREWCALENDAR
        public 
#else
        private
#endif
            bool IsYomTovAssurBemelacha(JewishHoliday holidayIndex)
        {
            return holidayIndex is JewishHoliday.פסח or JewishHoliday.שבועות or
                   JewishHoliday.סוכות or JewishHoliday.שמיני_עצרת or
                   JewishHoliday.שמחת_תורה or JewishHoliday.ראש_השנה or
                   JewishHoliday.יום_כיפור;
        }

        /// <summary>
        /// Returns true if the current day is Chol Hamoed of Pesach or Succos.
        /// </summary>
        /// <returns>true if the current day is Chol Hamoed of Pesach or Succos</returns>
#if NOHEBREWCALENDAR
        public 
#else
        private
#endif
            bool IsCholHamoed(JewishHoliday holidayIndex)
        {
            return holidayIndex is JewishHoliday.חול_המועד_פסח or JewishHoliday.חול_המועד_סוכות;
        }


        /// <summary>
        /// Returns the int value of the Omer day or -1 if the day is not in the omer
        /// </summary>
        /// <returns>The Omer count as an int or -1 if it is not a day of the Omer.</returns>
#if NOHEBREWCALENDAR
        public 
#else
        private
#endif
            int GetDayOfOmer(JewishMonth jewishMonth, int dayOfMonth)
        {
            int omer = -1; // not a day of the Omer

            // if Nissan and second day of Pesach and on
            if (jewishMonth == JewishMonth.NISSAN && dayOfMonth >= 16)
            {
                omer = dayOfMonth - 15;
                // if Iyar
            }
            else if (jewishMonth == JewishMonth.IYAR)
            {
                omer = dayOfMonth + 15;
                // if Sivan and before Shavuos
            }
            else if (jewishMonth == JewishMonth.SIVAN && dayOfMonth < 6)
            {
                omer = dayOfMonth + 44;
            }

            return omer;
        }
    }

#if !NOHEBREWCALENDAR

    /// <summary>
    /// Jewish calendar. Extends HebrewCalendar to provide things like Jewish info (holidays etc.) and jewish months
    /// </summary>
    public partial class JewishCalendar : System.Globalization.HebrewCalendar
    {

        /// <summary>
        /// Determines whether this instance is leap year from date time the specified dt.
        /// </summary>
        /// <returns><c>true</c> if this instance is leap year from date time the specified dt; otherwise, <c>false</c>.</returns>
        /// <param name="dt">Dt.</param>
        public bool IsLeapYearFromDateTime(DateTime dt)
        {
            return IsLeapYear(GetYear(dt));
        }

        /// <summary>
        /// Gets the jewish month.
        /// </summary>
        /// <returns>The jewish month.</returns>
        /// <param name="dt">Dt.</param>
        public JewishMonth GetJewishMonth(DateTime dt)
        {
            return NativeMonthToJewishMonth(GetMonth(dt), IsLeapYearFromDateTime(dt));
        }

        /// <summary>
        /// Gets the jewish date time.
        /// </summary>
        /// <returns>The jewish date time.</returns>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        public DateTime GetJewishDateTime(int year, JewishMonth month, int day)
        {
            return ToDateTime(year, JewishMonthToNativeMonth(month, IsLeapYear(year)), day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the jewish year type.
        /// </summary>
        /// <returns>SHELAIMIM, KESIDRAN or CHASERIM.</returns>
        public JewishYearType GetJewishYearType(DateTime dt)
        {
            JewishYearType jType = JewishYearType.SHELAIMIM;

            if (MonthIs29Days(dt, JewishMonth.CHESHVAN))
            {
                jType = JewishYearType.KESIDRAN;
                if (MonthIs29Days(dt, JewishMonth.KISLEV))
                {
                    jType = JewishYearType.CHASERIM;
                }
            }

            return jType;
        }

        /// <summary>
        /// Months the is 29 days / short
        /// </summary>
        /// <returns><c>true</c>, if is29 days was monthed, <c>false</c> otherwise.</returns>
        /// <param name="dt">Dt.</param>
        /// <param name="month">Month.</param>
        public bool MonthIs29Days(DateTime dt, JewishMonth month)
        {
            return GetJewishDaysInMonth(dt, month) == 29;
        }


        /// <summary>
        /// Gets the jewish days in month.
        /// </summary>
        /// <returns>The jewish days in month.</returns>
        /// <param name="dt">Dt.</param>
        /// <param name="month">Month.</param>
        public int GetJewishDaysInMonth(DateTime dt, JewishMonth month)
        {
            return GetJewishDaysInMonth(GetYear(dt), month);
        }


        /// <summary>
        /// Gets the jewish days in month.
        /// </summary>
        /// <returns>The jewish days in month.</returns>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        public int GetJewishDaysInMonth(int year, JewishMonth month)
        {
            int nativeMonth = JewishMonthToNativeMonth(month, IsLeapYear(year));
            return GetDaysInMonth(year, nativeMonth);
        }

        /// <summary>
        /// Gets the jewish holiday, sets "use modern holidays" to true
        /// </summary>
        /// <returns>The jewish holiday.</returns>
        /// <param name="dt">Dt.</param>
        /// <param name="inIsrael">If set to <c>true</c> in israel.</param>
        public JewishHoliday GetJewishHoliday(DateTime dt, bool inIsrael)
        {
            return GetJewishHoliday(dt, inIsrael, true);
        }

        public JewishHoliday GetJewishHoliday(DateTime dt, bool inIsrael, bool useModernHolidays)
        {
            JewishMonth hebrewMonth = GetJewishMonth(dt);

            return GetJewishHoliday(GetDayOfMonth(dt), GetJewishDayOfWeek(dt), GetYear(dt),
                        inIsrael, useModernHolidays, hebrewMonth,
                        MonthIs29Days(dt, JewishMonth.KISLEV)
                   );
        }

        /// <summary>
        /// Returns true if the current day is Yom Tov. The method returns false for Chanukah, Erev Yom Tov (with the
        /// exception of Hoshana Rabba and Erev the second days of Pesach) and fast days.
        /// </summary>
        /// <returns>true if the current day is a Yom Tov</returns>
        public bool IsYomTov(DateTime dt, bool inIsrael)
        {
            JewishHoliday holidayIndex = GetJewishHoliday(dt, inIsrael);

            return (!IsErevYomTov(dt, inIsrael) || holidayIndex == JewishHoliday.הושענא_רבה || holidayIndex != JewishHoliday.חול_המועד_פסח || GetDayOfMonth(dt) == 20)
                && holidayIndex != JewishHoliday.חנוכה && (!IsTaanis(dt, inIsrael) || holidayIndex == JewishHoliday.יום_כיפור) && holidayIndex != JewishHoliday.אין;
        }

        /// <summary>
        /// This method will return false for a non Yom Tov day, even if it is Shabbos.
        /// </summary>
        /// <returns>if the Yom Tov day has a melacha (work)  prohibition.</returns>
        public bool IsYomTovAssurBemelacha(DateTime dt, bool inIsrael)
        {
            JewishHoliday holidayIndex = GetJewishHoliday(dt, inIsrael);
            return IsYomTovAssurBemelacha(holidayIndex);
        }



        /// <summary>
        /// Returns true if the current day is Chol Hamoed of Pesach or Succos.
        /// </summary>
        /// <returns>true if the current day is Chol Hamoed of Pesach or Succos</returns>
        public bool IsCholHamoed(DateTime dt, bool inIsrael)
        {
            JewishHoliday holidayIndex = GetJewishHoliday(dt, inIsrael);
            return IsCholHamoed(holidayIndex);
        }

        /// <summary>
        /// Returns true if the current day is erev Yom Tov. The method returns true for Erev - Pesach (first and last days),
        /// Shavuos, Rosh Hashana, Yom Kippur and Succos and Hoshana Rabba.
        /// </summary>
        /// <returns>true if the current day is Erev - Pesach, Shavuos, Rosh Hashana, Yom Kippur and Succos</returns>
        public bool IsErevYomTov(DateTime dt, bool inIsrael)
        {
            JewishHoliday holidayIndex = GetJewishHoliday(dt, inIsrael);
            return holidayIndex == JewishHoliday.ערב_פסח || holidayIndex == JewishHoliday.ערב_שבועות || holidayIndex == JewishHoliday.ערב_ראש_השנה
                || holidayIndex == JewishHoliday.ערב_יום_כיפור || holidayIndex == JewishHoliday.ערב_סוכות || holidayIndex == JewishHoliday.הושענא_רבה
                || (holidayIndex == JewishHoliday.חול_המועד_פסח && GetDayOfMonth(dt) == 20);
        }
        /// <summary>
        /// Returns true if the current day is Erev Rosh Chodesh. Returns false for Erev Rosh Hashana
        /// </summary>
        /// <returns>true if the current day is Erev Rosh Chodesh. Returns false for Erev Rosh Hashana</returns>
        public bool IsErevRoshChodesh(DateTime dt)
        {
            // Erev Rosh Hashana is not Erev Rosh Chodesh.
            return GetDayOfMonth(dt) == 29 && GetJewishMonth(dt) != JewishMonth.ELUL;
        }

        /// <summary>
        /// Return true if the day is a Taanis (fast day). Return true for 17 of Tammuz, Tisha B'Av, Yom Kippur, Fast of
        /// Gedalyah, 10 of Teves and the Fast of Esther
        /// </summary>
        /// <returns>true if today is a fast day</returns>
        public bool IsTaanis(DateTime dt, bool inIsrael)
        {
            JewishHoliday holidayIndex = GetJewishHoliday(dt, inIsrael);
            return holidayIndex is JewishHoliday.שבעה_עשר_בתמוז or JewishHoliday.תשעה_באב or JewishHoliday.יום_כיפור
                or JewishHoliday.צום_גדליה or JewishHoliday.עשירי_בטבת or JewishHoliday.צום_אסתר;
        }

        /// <summary>
        /// Returns the day of Chanukah or -1 if it is not Chanukah.
        /// </summary>
        /// <returns>the day of Chanukah or -1 if it is not Chanukah.</returns>
        public int GetDayOfChanukah(DateTime dt)
        {
            return IsChanukah(dt)
                ? GetJewishMonth(dt) == JewishMonth.KISLEV
                    ? GetDayOfMonth(dt) - 24
                    : MonthIs29Days(dt, JewishMonth.KISLEV) ? GetDayOfMonth(dt) + 5 : GetDayOfMonth(dt) + 6
                : -1;
        }

        /// <summary>
        /// Returns if the day is Chanukah. 
        /// </summary>
        /// <returns>if the day is Chanukah</returns>
        public bool IsChanukah(DateTime dt)
        {
            //israel settings don't matter, but would rather catch it with compiler elsewhere
            return GetJewishHoliday(dt, true) == JewishHoliday.חנוכה;
        }

        /// <summary>
        /// Returns if the day is Rosh Chodesh. Rosh Hashana will return false
        /// </summary>
        /// <returns>if the day is Rosh Chodesh. Rosh Hashana will return false</returns>
        public bool IsRoshChodesh(DateTime dt)
        {
            // Rosh Hashana is not rosh chodesh. Elul never has 30 days
            return (GetDayOfMonth(dt) == 1 && GetJewishMonth(dt) != JewishMonth.TISHREI) || GetDayOfMonth(dt) == 30;
        }

        /// <summary>
        /// Returns the int value of the Omer day or -1 if the day is not in the omer
        /// </summary>
        /// <returns>The Omer count as an int or -1 if it is not a day of the Omer.</returns>
        public int GetDayOfOmer(DateTime dt)
        {
            return GetDayOfOmer(GetJewishMonth(dt), GetDayOfMonth(dt));
        }

        /// <summary>
        /// Return the type of year for parsha calculations.
        /// The algorithm follows the
        /// <a href="http://hebrewbooks.org/pdfpager.aspx?req=14268&amp;st=&amp;pgnum=222"> Luach Arba'ah Shearim</a> in the Tur Ohr Hachaim.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="inIsrael"></param>
        /// <returns>the type of year for parsha calculations.</returns>
        private int GetParshaYearType(DateTime date, bool inIsrael)
        {


            int roshHashanaDayOfWeek = (int)base.GetDayOfWeek(base.ToDateTime(base.GetYear(date), 1, 1, 14, 0, 0, 0));

            if (base.IsLeapYear(base.GetYear(date)))
            {
                switch (roshHashanaDayOfWeek)
                {
                    case (int)DayOfWeek.Monday:
                        if (IsKislevShort(date))
                        { //BaCh
                            return inIsrael ? 14 : 6;
                        }
                        if (IsCheshvanLong(date))
                        { //BaSh
                            return inIsrael ? 15 : 7;
                        }
                        break;
                    case (int)DayOfWeek.Tuesday: //Gak
                        if (inIsrael)
                        {
                            return 15;
                        }
                        return 7;
                    case (int)DayOfWeek.Thursday:
                        if (IsKislevShort(date))
                        { //HaCh
                            return 8;
                        }
                        if (IsCheshvanLong(date))
                        { //HaSh
                            return 9;
                        }
                        break;
                    case (int)DayOfWeek.Saturday:
                        if (IsKislevShort(date))
                        { //ZaCh
                            return 10;
                        }
                        if (IsCheshvanLong(date))
                        { //ZaSh
                            return inIsrael ? 16 : 11;
                        }
                        break;
                    default:
                        break;//TODO add code to handle exception
                }
            }
            else
            { //not a leap year
                switch (roshHashanaDayOfWeek)
                {
                    case (int)DayOfWeek.Monday:
                        if (IsKislevShort(date))
                        { //BaCh
                            return 0;
                        }
                        if (IsCheshvanLong(date))
                        { //BaSh
                            return inIsrael ? 12 : 1;
                        }
                        break;
                    case (int)DayOfWeek.Tuesday: //GaK
                        if (inIsrael)
                        {
                            return 12;
                        }
                        return 1;
                    case (int)DayOfWeek.Thursday:
                        if (IsCheshvanLong(date))
                        { //HaSh
                            return 3;
                        }
                        if (!IsKislevShort(date))
                        { //Hak
                            return inIsrael ? 13 : 2;
                        }
                        break;
                    case (int)DayOfWeek.Saturday:
                        if (IsKislevShort(date))
                        { //ZaCh
                            return 4;
                        }
                        if (IsCheshvanLong(date))
                        { //ZaSh
                            return 5;
                        }
                        break;
                    default:
                        break;//TODO add code to handle exception
                }
            }
            return -1; //keep the compiler happy
        }

        /// <summary>
        /// Gets the current <seealso cref="Parsha"/> outside israel, based on the date
        /// </summary>
        /// <param name="date">the date of the shabbos</param>
        /// <returns>The current parsha outside israel if its a shabbos and there is a parsha, else returns <seealso cref=""""/></returns>
        //public Parsha GetParshah(DateTime date)
        //{
        //    date = new DateTime(date.Year, date.Month, date.Day, 14, 0, 0);


        //    int yearType = GetParshaYearType(date, false);
        //    int roshHashanaDayOfWeek = (int)base.GetDayOfWeek(base.ToDateTime(base.GetYear(date), 1, 1, 14, 0, 0, 0));
        //    TimeSpan daysSinceRoshHashana = date - base.ToDateTime(base.GetYear(date), 1, 1, 14, 0, 0, 0);
        //    int day = roshHashanaDayOfWeek + daysSinceRoshHashana.Days + 1;


        //    if (yearType >= 0)
        //    { // negative year should be impossible, but lets cover all bases
        //        return ParshaList[yearType, (day / 7) + 1];
        //    }
        //    return ""; //keep the compiler happy
        //}
        public string GetParshah(DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day, 14, 0, 0);


            int yearType = GetParshaYearType(date, false);
            int roshHashanaDayOfWeek = (int)base.GetDayOfWeek(base.ToDateTime(base.GetYear(date), 1, 1, 14, 0, 0, 0));
            TimeSpan daysSinceRoshHashana = date - base.ToDateTime(base.GetYear(date), 1, 1, 14, 0, 0, 0);
            int day = roshHashanaDayOfWeek + daysSinceRoshHashana.Days + 1;


            return yearType >= 0 ? ParshaListString[yearType, (day / 7) + 1] : "";
        }

        /// <summary>
        /// Gets the current <seealso cref="Parsha"/> in or outside israel, based on the date
        /// </summary>
        /// <param name="date">the date of the shabbos</param>
        /// <param name="inIsrael">true if in israel</param>
        /// <returns>The current parsha if its a shabbos and there is a parsha, else returns <seealso cref=""""/></returns>
        //public Parsha GetParshah(DateTime date, bool inIsrael)
        //{
        //    date = new DateTime(date.Year, date.Month, date.Day, 14, 0, 0);
        //    if (date.DayOfWeek != DayOfWeek.Saturday)
        //    {
        //        return "";
        //    }

        //    int yearType = GetParshaYearType(date, inIsrael);
        //    int roshHashanaDayOfWeek = (int)base.GetDayOfWeek(base.ToDateTime(base.GetYear(date), 1, 1, 14, 0, 0, 0));
        //    TimeSpan daysSinceRoshHashana = date - base.ToDateTime(base.GetYear(date), 1, 1, 14, 0, 0, 0);
        //    int day = roshHashanaDayOfWeek + daysSinceRoshHashana.Days + 1;


        //    if (yearType >= 0)
        //    { // negative year should be impossible, but lets cover all bases
        //        return ParshaList[yearType, day / 7];
        //    }
        //    return ""; //keep the compiler happy
        //}


        private bool IsCheshvanLong(DateTime date)
        {
            return base.GetDaysInMonth(base.GetYear(date), 2) == 30;
        }

        private bool IsKislevShort(DateTime date)
        {
            return base.GetDaysInMonth(base.GetYear(date), 3) == 29;
        }

        private readonly string[,] ParshaListString = new string[,]{
        {"", "וילך", "האזינו", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל-פקודי", "ויקרא", "צו", "", "שמיני", "תזריע-מצורע", "אחרי מות-קדושים", "אמור", "בהר-בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך", "", "", "", "", ""},
        {"", "וילך", "האזינו", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל-פקודי", "ויקרא", "צו", "", "שמיני", "תזריע-מצורע", "אחרי מות-קדושים", "אמור", "בהר-בחוקותי", "במדבר", "", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת-בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך", "", "", "", "", "" },
        { "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל-פקודי", "ויקרא", "צו", "", "", "שמיני", "תזריע-מצורע", "אחרי מות-קדושים", "אמור", "בהר-בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים", "", "", "", ""},
        { "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "", "שמיני", "תזריע-מצורע", "אחרי מות-קדושים", "אמור", "בהר-בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים", "", "", "", ""},
        { "", "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל-פקודי", "ויקרא", "צו", "", "שמיני", "תזריע-מצורע", "אחרי מות-קדושים", "אמור", "בהר-בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים", "", "", "", ""},
        { "", "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל-פקודי", "ויקרא", "צו", "", "שמיני", "תזריע-מצורע", "אחרי מות-קדושים", "אמור", "בהר-בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך", "", "", "", ""},
        { "", "וילך", "האזינו", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "", "אחרי מות", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת-בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך", ""},
        { "", "וילך", "האזינו", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "", "", "אחרי מות", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים"},
        { "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "אחרי מות", "", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות", "מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים"},
        { "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "אחרי מות", "", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות", "מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך"},
        { "", "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "", "אחרי מות", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך"},
        { "", "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "", "אחרי מות", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת-בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך"},
        { "", "וילך", "האזינו", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל-פקודי", "ויקרא", "צו", "", "שמיני", "תזריע-מצורע", "אחרי מות-קדושים", "אמור", "בהר-בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך", "", "", "", "", ""},
        { "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל-פקודי", "ויקרא", "צו", "", "שמיני", "תזריע-מצורע", "אחרי מות-קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים", "", "", "", ""},
        { "", "וילך", "האזינו", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "", "אחרי מות", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך", ""},
        { "", "וילך", "האזינו", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "", "אחרי מות", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות", "מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים"},
        { "", "", "האזינו", "", "", "בראשית", "נח", "לך לך", "וירא", "חיי שרה", "תולדות", "ויצא", "וישלח", "וישב", "מקץ", "ויגש", "ויחי", "שמות", "וארא", "בא", "בשלח", "יתרו", "משפטים", "תרומה", "תצוה", "כי תישא", "ויקהל", "פקודי", "ויקרא", "צו", "שמיני", "תזריע", "מצורע", "", "אחרי מות", "קדושים", "אמור", "בהר", "בחוקותי", "במדבר", "נשוא", "בהעלותך", "שלח", "קרח", "חוקת", "בלק", "פנחס", "מטות-מסעי", "דברים", "ואתחנן", "עקב", "ראה", "שופטים", "כי תצא", "כי תבוא", "ניצבים-וילך"}
    };
    }
#endif
}
