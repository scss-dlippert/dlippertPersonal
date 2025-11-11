// Copyright (c) SC Strategic Solutions. All rights reserved.

using System;
using System.Collections.Generic;
using System.Data;
using MySCView.Common;
using MySCView.Data;
using MySCView.Interface;

namespace MySCView.Business
{
    public static class AbsenceCalendarsJobTitles
    {
        public static IEnumerable<IAbsenceCalendarsJobTitles> RetrieveList(object connectionOrTransaction)
        {
            var dt = AbsenceCalendarsJobTitlesDAL.RetrieveList(connectionOrTransaction);

            foreach (var row in dt.AsEnumerable())
            {
                yield return new AbsenceCalendarsJobTitlesRecord(row);
            }
        }

        public static IAbsenceCalendarsJobTitles RetrieveById(object connectionOrTransaction, int referId)
        {
            var dt = AbsenceCalendarsJobTitlesDAL.RetrieveById(connectionOrTransaction, referId);

            return new AbsenceCalendarsJobTitlesRecord(dt.Rows[0]);
        }

        public static int Save(object connectionOrTransaction, IAbsenceCalendarsJobTitles refer)
        {
            return AbsenceCalendarsJobTitlesDAL.Save(connectionOrTransaction, refer);
        }

        public static int Delete(object connectionOrTransaction, int referId)
        {
            return AbsenceCalendarsJobTitlesDAL.Delete(connectionOrTransaction, referId);
        }

        public static IAbsenceCalendarsJobTitles GetEmpty(int userId, DateTime? createdDateTime = null)
        {
            return new AbsenceCalendarsJobTitlesRecord
            {
                CreatedUsersId = userId,
                CreatedDateTime = createdDateTime ?? DateTime.Now,
                ModifiedUsersId = userId,
                ModifiedDateTime = createdDateTime ?? DateTime.Now
            };
        }
    }
    
    [Serializable]
    internal class AbsenceCalendarsJobTitlesRecord : IAbsenceCalendarsJobTitles
    {
        internal AbsenceCalendarsJobTitlesRecord(){}

        internal AbsenceCalendarsJobTitlesRecord(DataRow row)
        {
            Id = row.GetValueAs<int>("ID");

            CreatedUsersId = row.GetValueAs<int>("CreatedUsersID");
            CreatedDateTime = row.GetValueAs<DateTime>("CreatedDateTime");
            ModifiedUsersId = row.GetValueAs<int>("ModifiedUsersID");
            ModifiedDateTime = row.GetValueAs<DateTime>("ModifiedDateTime");

            AbsenceCalendarId = row.GetValueAsOrDefault("AbsenceCalendarId", 0);
            AbsenceCalendarName = row.GetValueAsOrDefault("AbsenceCalendarText", string.Empty);

            JobTitleId = row.GetValueAsOrDefault("JobTitleId", 0);
            JobTitleName = row.GetValueAsOrDefault("JobTitleText", string.Empty);
        }

        public int Id { get; set; }
        public int CreatedUsersId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int ModifiedUsersId { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public int AbsenceCalendarId { get; set; }
        public string AbsenceCalendarName { get; set; }
        public int JobTitleId { get; set; }
        public string JobTitleName { get; set; }
    }
}
