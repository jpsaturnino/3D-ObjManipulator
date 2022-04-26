from models.Indice import Indice

class Face:
  def __init__(self) -> None:
    self.indices = dict()
  
  def add_face(self, face) -> None:
    arr = []
    for i in face:
      v, vt, vn = i.split("/")
      arr.append(Indice(v, vt, vn))
    self.indices[len(self.indices)+1] = arr