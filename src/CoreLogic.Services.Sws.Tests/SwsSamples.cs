namespace CoreLogic.Services.Sws
{
    public class SwsSamples
    {
        public static string AuthenticateSuccess
        {
            get
            {
                return @"
                {
                    'authKey': 'NewAuthKey'
                }";
            }
        }

        public static string AuthorizedFeaturesSuccess
        {
            get
            {
                return @"
                {
                    'features': [
                        {
                            'description': 'All Licensed Products',
                            'name': 'AllLicensed'
                        }
                    ],
                    'operations': [
                        {
                            'description': 'SpatialRecordUTPremium',
                            'name': 'SpatialRecordUTPremium'
                        },
                        {
                            'description': 'Get Parcels',
                            'name': 'GetParcels'
                        },
                        {
                            'description': 'SpatialRecordOGPremium',
                            'name': 'SpatialRecordOGPremium'
                        }
                    ]
                }";
            }
        }

        public static string GeocodeSuccess
        {
            get
            {
                return @"
                {
                    'Location': {
                        'addressLine': '11902 BURNET RD',
                        'cityName': 'AUSTIN',
                        'details': {
                            'apn2': {
                                'string': [
                                    '0258080104',
                                    '0258080103'
                                ]
                            },
                            'crossStreet': '',
                            'crossStreetBase': '',
                            'crossStreetPrefix': '',
                            'crossStreetPrefixDirectional': '',
                            'crossStreetSuffix': '',
                            'crossStreetSuffixDirectional': '',
                            'houseNumber': '11902',
                            'isIntersection': false,
                            'matchCodeDescription': 'Matched unique number',
                            'streetName': 'BURNET RD',
                            'streetNameBase': 'BURNET',
                            'streetNamePrefix': '',
                            'streetNamePrefixDirectional': '',
                            'streetNameSuffix': 'RD',
                            'streetNameSuffixDirectional': '',
                            'unitNumber': '',
                            'unitType': ''
                        },
                        'geocodingDataset': 'STRUCTURE',
                        'inputAddress': '11902 BURNET ROAD, AUSTIN, TX  78758',
                        'latitude': 30.406014,
                        'longitude': -97.716997,
                        'matchCode': 'A0000',
                        'matchConfidence': 'HIGH',
                        'matchedAddress': '11902 BURNET RD,AUSTIN TX  78758',
                        'parcelID': {
                            'string': [
                                '548320',
                                '548319'
                            ]
                        },
                        'stateCode': 'TX',
                        'structureID': {
                            'string': [
                                '13808356',
                                '13808504',
                                '13808745',
                                '13808592'
                            ]
                        },
                        'uspsgeoLevel': '',
                        'uspsrecType': '',
                        'zipcode': '78758'
                    }
                }";
            }
        }

        public static string PageInfo
        {
            get
            {
                return @"
                {
                    'actualPageSize': 1,
                    'length': 1,
                    'maxPageSize': 50,
                    'page': 1,
                    'pageSize': 50
                }";
            }
        }

        public static string SpatialRecordLargePage1
        {
            get
            {
                return @"
                {
                    'pageInfo': {
                        'actualPageSize': 50,
                        'length': 80,
                        'maxPageSize': 50,
                        'page': 1,
                        'pageSize': 50
                    },
                    'parcels': [
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        }
                    ]
                }";
            }
        }

        public static string SpatialRecordLargePage2
        {
            get
            {
                return @"
                {
                    'pageInfo': {
                        'actualPageSize': 30,
                        'length': 80,
                        'maxPageSize': 50,
                        'page': 2,
                        'pageSize': 50
                    },
                    'parcels': [
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'ID',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        },
                        {
                            'STATE': 'TX',
                            'APN': '548319',
                            'FIPS_CODE': '48453'
                        }
                    ]
                }";
            }
        }

        public static string SpatialRecordParcel
        {
            get
            {
                return @"
                {
                    'STATE_CODE': '48',
                    'CNTY_CODE': '453',
                    'APN': '548319',
                    'APN2': '0258080103',
                    'ADDR': '11902 BURNET RD',
                    'CITY': 'AUSTIN',
                    'STATE': 'TX',
                    'ZIP': '78758',
                    'STD_ADDR': '11902 BURNET RD',
                    'STD_CITY': 'AUSTIN',
                    'STD_STATE': 'TX',
                    'STD_ZIP': '78758',
                    'STD_PLUS': '2972',
                    'GEOM': 'POLYGON ((-97.7 30.4, -97.7 30.5, -97.6 30.5, -97.6 30.4, -97.7 30.4))',
                    'FIPS_CODE': '48453',
                    'UNFRM_APN': '548319',
                    'APN_SEQ_NO': 1,
                    'FRM_APN': '548319',
                    'ORIG_APN': '548319',
                    'MAP_REF1': '465-Z',
                    'MAP_REF2': '2N',
                    'CENSUS_TR': '001841007',
                    'LOT_NBR': '2',
                    'LAND_USE': '244',
                    'PROP_IND': '27',
                    'SUB_NAME': 'NORTH LOOP BUS PARK SEC 01-A',
                    'OWN_CP_IND': 'Y',
                    'OWN1_LAST': 'CH REALTY VI/O AUSTIN STONECREEK',
                    'MAIL_NBR': '3819',
                    'MAIL_STR': 'MAPLE',
                    'MAIL_MODE': 'AVE',
                    'MAIL_CITY': 'DALLAS',
                    'MAIL_STATE': 'TX',
                    'MAIL_ZIP': '752193913',
                    'MAIL_CC': 'C041',
                    'TOT_VAL': 16291424,
                    'LAN_VAL': 3145900,
                    'IMP_VAL': 13145524,
                    'TOT_VAL_CD': 'M',
                    'LAN_VAL_CD': 'M',
                    'ASSD_VAL': 16291424,
                    'ASSD_LAN': 3145900,
                    'ASSD_IMP': 13145524,
                    'MKT_VAL': 16291424,
                    'MKT_LAN': 3145900,
                    'MKT_IMP': 13145524,
                    'APPR_VAL': 16291424,
                    'APPR_LAN': 3145900,
                    'APPR_IMP': 13145524,
                    'TAX_AMT': 410217.89,
                    'TAX_YR': 2017,
                    'ASSD_YR': 2016,
                    'TAX_AREA': '0A',
                    'DOC_NBR': '126817',
                    'LAND_ACRES': 3.611,
                    'LAND_SQ_FT': 157295,
                    'LOT_AREA': 'LAND',
                    'UBLD_SQ_FT': 77450,
                    'BLD_SQ_IND': 'B',
                    'BLD_SQ_FT': 77450,
                    'LIV_SQ_FT': 77450,
                    'GF_SQ_FT': 18725,
                    'GR_SQ_FT': 77450,
                    'YR_BLT': 1984,
                    'BLD_CODE': 'C60',
                    'CONSTR_TYP': '001',
                    'FOUNDATION': 'SLB',
                    'ROOF_COVER': '003',
                    'ROOF_TYP': 'F00',
                    'STORY_CD': '040',
                    'STORY_NBR': 4,
                    'BLD_UNITS': 1,
                    'UNITS_NBR': 5,
                    'LEGAL1': 'LOT 2 NORTH LOOP BUSINESS PARK SEC 1-A  '
                }";
            }
        }

        public static string SpatialRecordSuccess
        {
            get
            {
                return @"
                {
                    'pageInfo': {
                        'actualPageSize': 1,
                        'length': 1,
                        'maxPageSize': 50,
                        'page': 1,
                        'pageSize': 50
                    },
                    'parcels': [
                        {
                            'STATE_CODE': '48',
                            'CNTY_CODE': '453',
                            'APN': '548319',
                            'APN2': '0258080103',
                            'ADDR': '11902 BURNET RD',
                            'CITY': 'AUSTIN',
                            'STATE': 'TX',
                            'ZIP': '78758',
                            'STD_ADDR': '11902 BURNET RD',
                            'STD_CITY': 'AUSTIN',
                            'STD_STATE': 'TX',
                            'STD_ZIP': '78758',
                            'STD_PLUS': '2972',
                            'GEOM': 'POLYGON ((-97.7 30.4, -97.7 30.5, -97.6 30.5, -97.6 30.4, -97.7 30.4))',
                            'FIPS_CODE': '48453',
                            'UNFRM_APN': '548319',
                            'APN_SEQ_NO': 1,
                            'FRM_APN': '548319',
                            'ORIG_APN': '548319',
                            'MAP_REF1': '465-Z',
                            'MAP_REF2': '2N',
                            'CENSUS_TR': '001841007',
                            'LOT_NBR': '2',
                            'LAND_USE': '244',
                            'PROP_IND': '27',
                            'SUB_NAME': 'NORTH LOOP BUS PARK SEC 01-A',
                            'OWN_CP_IND': 'Y',
                            'OWN1_LAST': 'CH REALTY VI/O AUSTIN STONECREEK',
                            'MAIL_NBR': '3819',
                            'MAIL_STR': 'MAPLE',
                            'MAIL_MODE': 'AVE',
                            'MAIL_CITY': 'DALLAS',
                            'MAIL_STATE': 'TX',
                            'MAIL_ZIP': '752193913',
                            'MAIL_CC': 'C041',
                            'TOT_VAL': 16291424,
                            'LAN_VAL': 3145900,
                            'IMP_VAL': 13145524,
                            'TOT_VAL_CD': 'M',
                            'LAN_VAL_CD': 'M',
                            'ASSD_VAL': 16291424,
                            'ASSD_LAN': 3145900,
                            'ASSD_IMP': 13145524,
                            'MKT_VAL': 16291424,
                            'MKT_LAN': 3145900,
                            'MKT_IMP': 13145524,
                            'APPR_VAL': 16291424,
                            'APPR_LAN': 3145900,
                            'APPR_IMP': 13145524,
                            'TAX_AMT': 410217.89,
                            'TAX_YR': 2017,
                            'ASSD_YR': 2016,
                            'TAX_AREA': '0A',
                            'DOC_NBR': '126817',
                            'LAND_ACRES': 3.611,
                            'LAND_SQ_FT': 157295,
                            'LOT_AREA': 'LAND',
                            'UBLD_SQ_FT': 77450,
                            'BLD_SQ_IND': 'B',
                            'BLD_SQ_FT': 77450,
                            'LIV_SQ_FT': 77450,
                            'GF_SQ_FT': 18725,
                            'GR_SQ_FT': 77450,
                            'YR_BLT': 1984,
                            'BLD_CODE': 'C60',
                            'CONSTR_TYP': '001',
                            'FOUNDATION': 'SLB',
                            'ROOF_COVER': '003',
                            'ROOF_TYP': 'F00',
                            'STORY_CD': '040',
                            'STORY_NBR': 4,
                            'BLD_UNITS': 1,
                            'UNITS_NBR': 5,
                            'LEGAL1': 'LOT 2 NORTH LOOP BUSINESS PARK SEC 1-A  '
                        }
                    ]
                }";
            }
        }
    }
}