# 📡 מערכת מלשינון – Malshinon Intelligence Reporting System

מערכת דו-לשונית לניהול וניתוח דיווחים מודיעיניים.  
A bilingual system for collecting and analyzing intelligence reports.

---

## 🧭 תוכן | Contents

- [📌 תיאור הפרויקט | Project Description](#-תיאור-הפרויקט--project-description)
- [✅ מה עובד | Features (Implemented)](#-מה-עובד--features-implemented)
- [🛠️ מה בתכנון | Planned Features](#️-מה-בתכנון--planned-features)
- [📁 מבנה הפרויקט | Project Structure](#-מבנה-הפרויקט--project-structure)
- [🧠 הסבר על המחלקות | Class Breakdown](#-הסבר-על-המחלקות--class-breakdown)
- [🧪 תלויות | Dependencies](#-תלויות--dependencies)
- [🗂️ טבלאות לדוגמה | Example Tables](#-טבלאות-לדוגמה--example-tables)
- [✍️ יוצר המערכת | Author](#️-יוצר-המערכת--author)

---

## 📌 תיאור הפרויקט | Project Description

**עברית**:  
מערכת כללית לקליטת מידע מודיעיני וניתוחו.  
מאפשרת לכל אחד להזין דיווח, ועתידית תאפשר גם שליפת מידע למורשים בלבד.  
מזהה שמות מתוך הטקסט, מסווג מטרות פוטנציאליות או סוכנים, ומנהל סטטיסטיקות לפי קוד סודי או שם.

**English**:  
A general system for submitting and analyzing intelligence reports.  
Anyone can report, and in the future, only authorized users will retrieve data.  
The system extracts target names from text and tracks agents/threats based on reports and mentions.

---

## ✅ מה עובד | Features (Implemented)

- הוספת דיווח לפי שם מלא של המדווח  
  ✅ Report submission using full name  
- יצירת משתמש חדש אם לא קיים  
  ✅ Automatic creation of new people if not in database  
- יצירת קוד סודי אקראי בן 7 תווים  
  ✅ 7-character random unique secret code generation  
- בדיקת ייחודיות של הקוד  
  ✅ Uniqueness check for each secret code  
- חילוץ שמות מתוך טקסט הדיווח  
  ✅ Target name extraction from report text  
- עדכון מספר דיווחים / אזכורים  
  ✅ Update `num_reports` and `num_mentions` accordingly

---

## 🛠️ מה בתכנון | Planned Features

- ⏳ דיווח לפי קוד סודי במקום שם  
  Report by secret code only  
- ⏳ מערכת קבצי לוג  
  Log file system to track operations  
- ⏳ תצוגה לפי סינון סוגים (סוכן, יעד, רגיל)  
  Filter people by role (agent, threat, etc.)

---

## 📁 מבנה הפרויקט | Project Structure

| קובץ | תיאור |
|------|--------|
| `PeopleDAL.cs` | ניהול טבלת אנשים (People) |
| `IntelReportsDAL.cs` | ניהול דיווחים וניתוח טקסט |
| `Menu.cs` | ממשק קונסול |

---

## 🧠 הסבר על המחלקות | Class Breakdown

### 👤 PeopleDAL.cs
**עברית**: ניהול מידע על אנשים (מדווחים, מטרות, סוכנים וכו').  
**English**: Handles operations for people (reporters, targets, etc.).

- `AddPeople(first, last, type)`
- `ChackSecretC(secret)`
- `GetPeopleByType(type)`
- `PeopleToString(type)`

---

### 🕵️ IntelReportsDAL.cs
**עברית**: ניהול רשומות דיווח והסקת מטרות מהטקסט.  
**English**: Stores reports and analyzes the text for targets.

- `AddIntelReports(secret, text)`
- `FindIdBbySecretcode(secret)`
- `FindTarget(text)`
- `FindIdBbyFullname([first, last])`
- `UpdateNumFlusOne(column, id)`
- `ChackPotentialAtent(id)`
- `ChackPotentialThragt(id)`

---

### 📋 Menu.cs
**עברית**: תפריט קונסול בסיסי לשליטה בפעולות.  
**English**: Interactive console menu for user interaction.

#### זרימה | Flow:
1. המשתמש בוחר להזין דיווח / User chooses to submit a report  
2. אם יש לו קוד – הדיווח נשמר / If they have a code → report is stored  
3. אם לא – המערכת רושמת אותו ומבקשת טקסט / Otherwise, registers as new reporter  
4. המערכת מעדכנת סטטיסטיקות / Stats are updated (reporter + target)

---

## 🧪 תלויות | Dependencies

- [`MySql.Data`](https://www.nuget.org/packages/MySql.Data) – חיבור ל־MySQL  
  MySQL database connector  
- `System.Data` – פעולות בסיסיות מול מסד נתונים  
  CRUD operations

---

## 🗂️ טבלאות לדוגמה | Example Tables

### `people` Table

| id | firstName | lastName | type             | secret_code | num_reports | num_mentions |
|----|-----------|----------|------------------|-------------|-------------|---------------|
| 1  | Yossi     | Cohen    | reporter         | X7A9B2C     | 5           | 0             |
| 2  | Lior      | Barak    | potential_threat | M5N8D4E     | 0           | 22            |

### `intelreports` Table

| report_id | reporter_id | target_id | text                        |
|-----------|-------------|-----------|-----------------------------|
| 1         | 1           | 2         | Lior Barak was seen...      |

---

## ✍️ יוצר המערכת | Author

- Developed by: [David Teichman]  
- GitHub: [github/davidtiechman/projectmalshinon]

---
