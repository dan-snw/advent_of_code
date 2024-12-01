import argparse
import shutil
import os
from datetime import datetime

def formatDay(day):
    try:
        dayInt = int(day)
    except Exception as e:
        raise ValueError("Day must be an integer.")

    if dayInt < 1 or dayInt > 24:
        raise ValueError("Day must be between 1 and 24.")

    return f"{dayInt:02}"

def formatYear(year):
    try:
        yearInt = int(year)
    except Exception as e:
        raise ValueError("Year must be an integer.")

    if yearInt < 2015 or yearInt > datetime.now().year:
        raise ValueError(f"Day must be between 2015 and {datetime.now().year}")

    return f"{yearInt:02}"

def replace_text_in_file(file_path, old_text, new_text):
    try:
        with open(file_path, 'r') as file:
            content = file.read()
        
        updated_content = content.replace(old_text, new_text)
        
        with open(file_path, 'w') as file:
            file.write(updated_content)
        
    except Exception as e:
        print(f"Error while replacing text: {e}")

def main():
    parser = argparse.ArgumentParser(description = "Process day and year flags.")
    
    parser.add_argument('--day', type = int, required = True, help = "Specify the day (e.g., 1, 15, 31).")
    parser.add_argument('--year', type = int, required = True, help = "Specify the year (e.g., 2024).")
    
    args = parser.parse_args()

    day = formatDay(args.day)
    year = formatYear(args.year)
    
    source_path = os.path.expanduser("./DayTemplate.cs")
    destination_directoy = f"../AOC/Days{year}/Day{day}"
    os.makedirs(destination_directoy, exist_ok = True) 
    destination_path = os.path.expanduser(f"{destination_directoy}/Day{day}.cs")

    try:
        shutil.copy(source_path, destination_path)
    except FileNotFoundError:
        print(f"Missing template.")
    except Exception as e:
        print(f"Could not copy template file: {e}")

    replace_text_in_file(destination_path, "YEAR_NUMBER", year)
    replace_text_in_file(destination_path, "CLASS_NAME", f"Day{day}")
    replace_text_in_file(destination_path, "DAY_NUMBER", f"{int(day)}")

if __name__ == "__main__":
    main()

