# parses the passports: each passport is saved as an array
# where each array value is one passport entry
def parse_passports():

    passports = []

    with open('./input.txt') as file:
        passport = {}
        while True:
            line = file.readline()
            # new passport
            if line in ['\n', '\r\n', '']:
                passports.append(passport)
                passport = {}
            else:
                # get all entries in the current line and add them to the passport
                fields = line.replace('\n', '').split(' ')
                for field in fields:
                    key, value = field.split(':')
                    passport[key] = value

            # readline() returns '' if the file is at the end.
            # we need to use readline() instead of a for loop
            # to make sure that we add the last line as well!
            if line == '':
                break

    return passports


# make sure the value is between two numbers
def validate_min_max(value: int, min, max):
    return value >= min and value <= max

# validate 'byr' (Birth Year)
# - four digits; at least 1920 and at most 2002.
def validate_byr(value):
    return validate_min_max(int(value), 1920, 2002)

# validate 'iyr' (Issue Year)
# - four digits; at least 2010 and at most 2020.
def validate_iyr(value):
    return validate_min_max(int(value), 2010, 2020)

# validate 'eyr' (Expiration Year)
# - four digits; at least 2020 and at most 2030.
def validate_eyr(value):
    return validate_min_max(int(value), 2020, 2030)

# validate 'hgt' (Height)
# - a number followed by either cm or in:
#     If cm, the number must be at least 150 and at most 193.
#     If in, the number must be at least 59 and at most 76.
def validate_hgt(value):
    if 'cm' in value:
        height = value.split('cm')[0]
        return validate_min_max(int(height), 150, 193)
    elif 'in' in value:
        height = value.split('in')[0]
        return validate_min_max(int(height), 59, 76)
    return False

# validate 'hcl' (Hair Color)
# - a # followed by exactly six characters 0-9 or a-f.
def validate_hcl(value):
    if '#' in value:
        color = value.split('#')[1]
        return validate_min_max(int(color, 16), 0, int('ffffff', 16))
    return False

# validate 'ecl' (Eye Color)
# - exactly one of: amb blu brn gry grn hzl oth.
def validate_ecl(value):
    return value in ['amb', 'blu', 'brn', 'gry', 'grn', 'hzl', 'oth']

# validate 'pid' (Passport ID)
# - a nine-digit number, including leading zeroes.
def validate_pid(value):
    return value.isdigit() and len(value) == 9

# validate 'cid' (Country ID)
# - ignored, missing or not.
def validate_cid(value):
    return True


# validate a field of the passport
def validate_field(key, value):
    validator = {
        'byr': validate_byr,
        'iyr': validate_iyr,
        'eyr': validate_eyr,
        'hgt': validate_hgt,
        'hcl': validate_hcl,
        'ecl': validate_ecl,
        'pid': validate_pid,
        'cid': validate_cid,
    }
    return validator[key](value)


passport_field_ids = ['byr', 'iyr', 'eyr', 'hgt', 'hcl', 'ecl', 'pid'] # ignore 'cid'
valid_passport_count = 0
validated_passport_count = 0

passports = parse_passports()
for passport in passports:

    valid_field_ids = 0
    validated_field_ids = 0
    for field_key, field_value in passport.items():
        if field_key in passport_field_ids:
            valid_field_ids += 1
            if validate_field(field_key, field_value):
                validated_field_ids += 1

    if valid_field_ids == len(passport_field_ids):
        valid_passport_count += 1
    if validated_field_ids == len(passport_field_ids):
        validated_passport_count += 1

print('Valid passports (part 1): %s' % valid_passport_count)
print('Validated passports (part 2): %s' % validated_passport_count)