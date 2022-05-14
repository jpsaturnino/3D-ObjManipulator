# 3D-ObjManipulator

This is an tool to manipulation 3d objects make in python with your mouse.

Clone repositorie to your machine
```bash
    git clone https://github.com/jpsaturnino/3D-ObjManipulator.git
    cd 3D-ObjManipulator
```
 


To create the virtual environment and install the libraries required, execute in your bash the following commands:
Needs python ~>3.8 installed in you machine
- In linux
```bash
    sudo apt install python3-venv
	sudo apt-get install python3.8-tk
    python -m venv venv
    source venv/bin/activate
    pip install -r requirements.txt
```

- In Windows >=10
```bash
    pip install virtualenv
    python -m virtualenv venv # or python -m venv venv
	.\venv\Scripts\activate
    pip install -r requirements.txt
```

To execute the tool in your virtualenv, in your bash execute
```bash
	# in windows >=10
    python main.py
    # or in linux
    python3 main.py
```
