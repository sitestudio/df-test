import random
from datetime import datetime, timedelta

# Function to generate a random date
def random_date(start, end):
    return start + timedelta(days=random.randint(0, (end - start).days))

# Sample data generation
def generate_student_schedules_response(num_records=100):
    responses = []
    for _ in range(num_records):
        date = random_date(datetime(2023, 1, 1), datetime(2023, 12, 31)).isoformat()
        day_type = {
            "code": random.choice(["Regular", "Special", "Holiday"]),
            "description": random.choice(["Regular School Day", "Special Event", "Public Holiday"])
        }
        
        schedules = []
        for _ in range(random.randint(1, 5)):  # Each student can have between 1 to 5 schedules
            day_cycle_code = random.choice(["A", "B", "C"])
            timetable_version = {
                "id": random.randint(1, 10),
                "name": f"Version {random.randint(1, 10)}"
            }
            
            periods = []
            for _ in range(random.randint(1, 4)):  # Each schedule can have between 1 to 4 periods
                period = {
                    "dayConfigId": random.randint(1, 100),
                    "dayConfigType": {
                        "code": random.choice(["Main", "Supplementary"]),
                        "description": random.choice(["Main Day Configuration", "Supplementary Configuration"])
                    },
                    "startTime": random_date(datetime(2023, 1, 1), datetime(2023, 12, 31)).isoformat() + "T08:00:00",
                    "endTime": random_date(datetime(2023, 1, 1), datetime(2023, 12, 31)).isoformat() + "T15:00:00",
                    "itemName": f"Period {random.randint(1, 10)}",
                    "shortName": f"P{random.randint(1, 10)}",
                    "isTeachingAllocation": random.choice([True, False]),
                    "classes": [{
                        "hasAttendanceChanges": random.choice([True, False]),
                        "attendanceStatus": {
                            "code": random.choice(["Present", "Absent", "Late"]),
                            "description": random.choice(["Present", "Absent", "Late"])
                        },
                        "timetableClassId": random.randint(1, 1000),
                        "startTime": random_date(datetime(2023, 1, 1), datetime(2023, 12, 31)).isoformat() + "T08:00:00",
                        "endTime": random_date(datetime(2023, 1, 1), datetime(2023, 12, 31)).isoformat() + "T15:00:00",
                        "className": f"Class {random.randint(1, 20)}",
                        "activity": {
                            "code": random.choice(["Lecture", "Lab", "Seminar"]),
                            "description": random.choice(["Lecture", "Laboratory Work", "Seminar"])
                        },
                        "learningArea": {
                            "code": random.choice(["Math", "Science", "Arts"]),
                            "description": random.choice(["Mathematics", "Natural Sciences", "Fine Arts"])
                        },
                        "facility": {
                            "code": random.choice(["B1", "B2", "C3"]),
                            "description": random.choice(["Block 1", "Block 2", "Block 3"])
                        },
                        "classType": {
                            "code": random.choice(["Regular", "Composite"]),
                            "description": random.choice(["Regular Class", "Composite Class"])
                        },
                        "isCompositeClass": random.choice([True, False]),
                        "isRollMarkable": random.choice([True, False]),
                        "notRollMarkableReason": {
                            "code": random.choice(["N/A", "Instructor unavailable"]),
                            "description": random.choice(["Not applicable", "Instructor unavailable"])
                        },
                        "isRollMarked": random.choice([True, False]),
                        "rollMarkedDate": random.choice([None, random_date(datetime(2023, 1, 1), datetime(2023, 12, 31)).isoformat()]),
                        "rollMarkedUser": random.choice([None, "user123", "admin"]),
                        "session": random.choice(["AM", "PM"]),
                        "yearLevel": {
                            "code": random.choice(["1", "2", "3", "4", "5"]),
                            "description": "Year " + random.choice(["1", "2", "3", "4", "5"])
                        },
                        "teachers": [{
                            "staffCentreId": random.randint(1, 100),
                            "title": random.choice(["Mr.", "Ms.", "Dr."]),
                            "familyName": random.choice(["Smith", "Jones", "Taylor"]),
                            "givenNames": random.choice(["John", "Mary", "Alice"]),
                            "timetableCode": random.choice(["T1", "T2", "T3"])
                        } for _ in range(random.randint(1, 3))]
                    }]
                }
                periods.append(period)
            
            schedule = {
                "dayCycleCode": day_cycle_code,
                "timetableVersion": timetable_version,
                "periods": periods
            }
            schedules.append(schedule)
        
        response = {
            "date": date,
            "dayType": day_type,
            "schedules": schedules
        }
        responses.append(response)
    
    return responses

# Generating 100 records
sample_records = generate_student_schedules_response(100)
sample_records_json = json.dumps(sample_records, indent=2)

# Output result
print(sample_records_json)