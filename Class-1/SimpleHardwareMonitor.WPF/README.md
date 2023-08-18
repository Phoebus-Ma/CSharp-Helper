
## Introduction

SimpleHardwareMonitor is a hardware monitor.
It uses the openhardwaremonitor library to implement the corresponding functions.


## Usage

Run as admin for SimpleHardwareMonitor.exe, otherwise you cannot see the power data.
My tests on windows 10 were successful.


## Issue

Running on windows 11, the Openhardwaremonitorlib.dll(v0.9.6) will be blocked from getting power data due to driver issues.


## Platform

- Windows 10+

- Visual Studio 2022/.Net Framework.

- Openhardwaremonitorlib.dll from openhardwaremonitor_v0.9.6.
