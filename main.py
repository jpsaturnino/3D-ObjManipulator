from models.Object import Object
from PyQt5 import QtCore, QtGui, QtWidgets

class Ui_MainWindow(object):
  def setupUi(self, MainWindow):
    MainWindow.setObjectName("MainWindow")
    MainWindow.resize(977, 600)
    self.centralwidget = QtWidgets.QWidget(MainWindow)
    self.centralwidget.setObjectName("centralwidget")
    self.openGLWidget = QtWidgets.QOpenGLWidget(self.centralwidget)
    self.openGLWidget.setGeometry(QtCore.QRect(10, 10, 781, 531))
    self.openGLWidget.setObjectName("openGLWidget")
    MainWindow.setCentralWidget(self.centralwidget)
    self.menubar = QtWidgets.QMenuBar(MainWindow)
    self.menubar.setGeometry(QtCore.QRect(0, 0, 977, 21))
    self.menubar.setObjectName("menubar")
    self.menuFile = QtWidgets.QMenu(self.menubar)
    self.menuFile.setObjectName("menuFile")
    MainWindow.setMenuBar(self.menubar)
    self.statusbar = QtWidgets.QStatusBar(MainWindow)
    self.statusbar.setObjectName("statusbar")
    MainWindow.setStatusBar(self.statusbar)
    self.actionChoose_File = QtWidgets.QAction(MainWindow)
    self.actionChoose_File.setObjectName("actionChoose_File")
    self.actionChoose_File.triggered.connect(self.open_file)
    self.actionClose_File = QtWidgets.QAction(MainWindow)
    self.actionClose_File.setObjectName("actionClose_File")
    self.menuFile.addAction(self.actionChoose_File)
    self.menuFile.addAction(self.actionClose_File)
    self.menubar.addAction(self.menuFile.menuAction())

    self.retranslateUi(MainWindow)
    QtCore.QMetaObject.connectSlotsByName(MainWindow)

  def retranslateUi(self, MainWindow):
    _translate = QtCore.QCoreApplication.translate
    MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
    self.menuFile.setTitle(_translate("MainWindow", "File"))
    self.actionChoose_File.setText(_translate("MainWindow", "Open File"))
    self.actionClose_File.setText(_translate("MainWindow", "Close File"))

  def open_file(self):
    file_name = QtWidgets.QFileDialog.getOpenFileName(None, 'Open File', './Modelos3D', '*.obj')
    read_file(file_name[0])

def read_file(file_name: str):
  with open(file_name) as f:
    obj = Object()
    for line in f:
      line = line.replace(",", ".")
      id_, x, y, z = line.split(" ")
      
      if id_ == 'f':
        obj.add_face([x, y, z.replace("\n", "")])
      else:
        x = float(x)
        y = float(y)
        z = float(z)
        if id_ == 'v':
          obj.add_vertice(x, y, z)
        elif id_ == 'vn':
          obj.add_normal_vertice(x, y, z)
  print("Arquivo obj lido com sucesso!")

if __name__ == "__main__":
  import sys
  app = QtWidgets.QApplication(sys.argv)
  MainWindow = QtWidgets.QMainWindow()
  ui = Ui_MainWindow()
  ui.setupUi(MainWindow)
  MainWindow.show()
  sys.exit(app.exec_())