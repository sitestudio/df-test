import random
from datetime import datetime, timedelta

def generate_sample_student_schedules(n=100):
    sample_records = []
    start_date = datetime.now()
    
    for _ in range(n):
        date = start_date + timedelta(days=random.randint(0, 30))  # Random date within the next 30 days
        day_type_code = random.choice(['A', 'B', 'C'])
        day_type_description = random.choice(['Normal', 'Short Day', 'Long Day'])
        
        # Generating random schedules
        schedules = []
        for _ in range(random.randint(1, 5)):  # 1 to 5 schedules per day
            day_cycle_code = random.choice(['Cycle 1', 'Cycle 2', 'Cycle 3'])
            timetable_version_id = random.randint(1, 10)
            timetable_version_name = random.choice(['Version 1', 'Version 2', 'Version 3'])
            
            periods = []
            for _ in range(random.randint(1, 4)):  # 1 to 4 periods in each schedule
                day_config_id = random.randint(1, 100)
                day_config_type_code = random.choice(['Type A', 'Type B'])
                day_config_type_description = random.choice(['Morning', 'Afternoon'])
                start_time = (datetime.combine(date, datetime.min.time()) + timedelta(hours=random.randint(8, 15))).isoformat()
                end_time = (datetime.combine(date, datetime.min.time()) + timedelta(hours=random.randint(16, 18))).isoformat()
                
                classes = []
                for _ in range(random.randint(1, 3)):  # Random number of classes per period
                    class_record = {
                        'hasAttendanceChanges': random.choice([True, False]),
                        'attendanceStatus': {
                            'code': random.choice(['Present', 'Absent', 'Late']),
                            'description': random.choice(['Attended', 'Did not attend', 'Arrived late'])
                        },
                        'timetableClassId': random.randint(1000, 2000),
                        'startTime': start_time,
                        'endTime': end_time,
                        'className': random.choice(['Math', 'Science', 'History']),
                        'activity': {
                            'code': random.choice(['Activity A', 'Activity B']),
                            'description': random.choice(['Lesson', 'Workshop'])
                        },
                        'learningArea': {
                            'code': random.choice(['LA1', 'LA2']),
                            'description': random.choice(['Mathematics', 'Science'])
                        },
                        'facility': {
                            'code': random.choice(['FAC1', 'FAC2']),
                            'description': random.choice(['Room 101', 'Lab 202'])
                        },
                        'classType': {
                            'code': random.choice(['Type 1', 'Type 2']),
                            'description': random.choice(['Regular', 'Special'])
                        },
                        'isCompositeClass': random.choice([True, False]),
                        'isRollMarkable': random.choice([True, False]),
                        'notRollMarkableReason': {
                            'code': random.choice(['Reason1', 'Reason2']),
                            'description': random.choice(['Not applicable', 'No reason'])
                        },
                        'isRollMarked': random.choice([True, False]),
                        'rollMarkedDate': datetime.now().isoformat() if random.choice([True, False]) else None,
                        'rollMarkedUser': random.choice(['User1', 'User2', None]),
                        'session': random.choice(['Session 1', 'Session 2']),
                        'yearLevel': {
                            'code': random.choice(['Year 1', 'Year 2']),
                            'description': random.choice(['First Year', 'Second Year'])
                        },
                        'teachers': [{
                            'staffCentreId': random.randint(1, 10),
                            'title': random.choice(['Mr.', 'Ms.', 'Mrs.']),
                            'familyName': random.choice(['Smith', 'Jones', 'Brown']),
                            'givenNames': random.choice(['John', 'Jane'])
                        } for _ in range(random.randint(1, 2))]  # Random number of teachers (1 or 2)
                    }
                    classes.append(class_record)
                
                period_record = {
                    'dayConfigId': day_config_id,
                    'dayConfigType': {
                        'code': day_config_type_code,
                        'description': day_config_type_description
                    },
                    'startTime': start_time,
                    'endTime': end_time,
                    'itemName': random.choice(['Item A', 'Item B']),
                    'shortName': random.choice(['Short A', 'Short B']),
                    'isTeachingAllocation': random.choice([True, False]),
                    'classes': classes
                }
                periods.append(period_record)

            schedule_record = {
                'dayCycleCode': day_cycle_code,
                'timetableVersion': {
                    'id': timetable_version_id,
                    'name': timetable_version_name
                },
                'periods': periods
            }
            schedules.append(schedule_record)

        record = {
            'date': date.isoformat(),
            'dayType': {
                'code': day_type_code,
                'description': day_type_description
            },
            'schedules': schedules
        }
        sample_records.append(record)
    
    return sample_records

# Generate 100 sample records for StudentSchedulesResponse
sample_student_schedules = generate_sample_student_schedules(100)