class Vertice:
  def __init__(self, x, y, z) -> None:
    self.x = x
    self.y = y
    self.z = z
  
  def to_string(self) -> str:
    return "Vertice: x: {}, y: {}, z: {}".format(self.x, self.y, self.z)