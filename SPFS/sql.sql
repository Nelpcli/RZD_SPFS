SELECT 	PI.ID,
		PI.NAME_SP,
			TSP.TYPE_SP,
				TP.TYPE_PLATFORM,
					TPS.TYPE_PLATFORM_SIZE,
						U.COUNT,
						U.NORM,
						U.COLORED_AREA,
								PVL_M.TYPE_PAVILION_MATERIAL_WALL,
							PVL.TYPE_PAVILION_MATERIAL_WALL_METER,
							PVL.TICKET,
							PVL.COLORED_AREA,
								B.COUNT,
								B.NORM,
								B.COLORED_AREA
		FROM PLATFORM_INFORMATION PI
			LEFT JOIN TYPE_SP TSP ON TSP.ID=PI.TYPE_SP
				LEFT JOIN TYPE_PLATFORM TP ON TP.ID=PI.TYPE_PLATFORM
					LEFT JOIN TYPE_PLATFORM_SIZE TPS ON TPS.ID=PI.TYPE_SIZE
						LEFT JOIN (select * from urn t 
where Data_change=(select Max(Data_change) from urn	
                   WHERE platform=t.platform
                   GROUP by Platform)) U ON U.PLATFORM=PI.ID
							LEFT JOIN (select * from PAVILION t 
where Data_change=(select Max(Data_change) from PAVILION	
                   WHERE platform=t.platform
                   GROUP by Platform))	 PVL ON PVL.PLATFORM=PI.ID
								LEFT JOIN TYPE_PAVILION_MATERIAL_WALL PVL_M ON PVL_M.ID=PVL.TYPE_PAVILION_MATERIAL_WALL
								LEFT JOIN (select * from BENCH t 
where Data_change=(select Max(Data_change) from BENCH	
                   WHERE platform=t.platform
                   GROUP by Platform)) B ON B.PLATFORM=PI.ID

												 
												 
(select * from urn t 
where Data_change=(select Max(Data_change) from urn	
                   WHERE platform=t.platform
                   GROUP by Platform))
				   
				   
(select * from BENCH t 
where Data_change=(select Max(Data_change) from BENCH	
                   WHERE platform=t.platform
                   GROUP by Platform))

(select * from PAVILION t 
where Data_change=(select Max(Data_change) from PAVILION	
                   WHERE platform=t.platform
                   GROUP by Platform))				   
								


insert into urn
(SELECT * FROM `urn` WHERE platform=1)



CREATE TEMPORARY TABLE tmp AS SELECT * FROM urn t WHERE platform=2 and Data_change=(select Max(Data_change) from urn	
                                                       WHERE platform=t.platform
                                                       GROUP by Platform);
update tmp 
	set id=(select max(id)+1 from urn),
    count=18,
    Data_change=CURTIME();
    
insert into urn select * FROM tmp;

string query = 

                "CREATE TEMPORARY TABLE tmp AS  SELECT * FROM " + table +
                                                " t WHERE " + field + "=" + value +
                                                " and Data_change = (select Max(Data_change) from " + table +
                                                                    " WHERE " + field +
                                                                                "= t." + field +
                                                       " GROUP by " + field + ");" +
                "update tmp " +
                    " set id = (select max(id) + 1 from " + table + ")," +
                    " " + field + "=" + DG1[e.ColumnIndex, e.RowIndex].Value.ToString() + "," +
                    "Data_change = CURTIME();" +

            "insert into " + table +
                    "select * FROM tmp;";


								
								
select 
  sum(case Item when 'Keyboard' then 1 else 0 end) as Keyboard,
  sum(case Item when 'Mouse' then 1 else 0 end) as Mouse,
  sum(case Item when 'Printer' then 1 else 0 end) as Printer
from [table]


select pi.ID,
	(case TC.Type_canopy when 'Типовой ВСЖД на платформе' then cp.count else 'null' end) as 'Типовой ВСЖД на платформе',
	(case TC.Type_canopy when 'Типовой ВСЖД вне платформы' then cp.count else 'null' end) as 'Типовой ВСЖД вне платформы',
	(case TC.Type_canopy when 'Типовой ЦДПО на платформе' then cp.count else 'null' end) as 'Типовой ЦДПО на платформе',
	(case TC.Type_canopy when 'Типовой ЦДПО вне платформы' then cp.count else 'null' end) as 'Типовой ЦДПО вне платформы',
	(case TC.Type_canopy when 'Не типовой на платформе' then cp.count else 'null' end) as 'Не типовой на платформе',
	(case TC.Type_canopy when 'Не типовой вне платформы' then cp.count else 'null' end) as 'Не типовой вне платформы'
from canopy cp
	left join type_canopy tc on tc.id=cp.type_canopy
		left join platform_information pi on pi.id=cp.platform
group by pi.id

Типовой ВСЖД вне платформы
Типовой ЦДПО на платформе
Типовой ЦДПО вне платформы
Не типовой на платформе
Не типовой вне платформы