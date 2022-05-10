from models.Vertice import Vertice
from models.Face import Face
import numpy as np

class Object:
  def __init__(self) -> None:
    self.faces = dict()
    self.vertices = dict()
    self.normal_vertices = dict()

    self.cur_vertices = dict()
    self.m_accumulated = np.identity(3)
    self.normal_faces = dict()
    self.normal_cur_faces = dict()

  def add_vertice(self, x, y, z) -> None:
    v = Vertice(x, y, z)
    self.vertices[len(self.vertices)+1] = v

  def add_cur_vertice(self, x, y, z) -> None:
    v = Vertice(x, y, z)
    self.vertices[len(self.vertices)+1] = v
  
  def add_normal_vertice(self, x, y, z) -> None:
    v = Vertice(x, y, z)
    self.normal_vertices[len(self.normal_vertices)+1] = v
  
  def add_face(self, face) -> None:
    f = Face()
    f.add_face(face)
    self.faces[len(self.faces)+1] = f

  def calculate_normal_vertice(self):
    for key in self.vertices:
      print(self.vertices[key].x, self.vertices[key].y, self.vertices[key].z)