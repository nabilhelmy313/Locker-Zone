﻿using AutoMapper;

namespace LockerZone.Application
{
    public class MappingProfileBase : Profile
    {
        public MappingProfileBase()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            ReplaceMemberName("_", "");
        }
        
        public static string GetCurrentLanguage()
        {
            return Thread.CurrentThread.CurrentCulture.ToString();
        }
    }
}

