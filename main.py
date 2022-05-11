from models.object_3d import *
from models.camera import *
from models.projection import *
import pygame as pg


class ObjectManipulator:
    def __init__(self):
        pg.init()
        self.RES = self.WIDTH, self.HEIGHT = 1280, 720
        self.H_WIDTH, self.H_HEIGHT = self.WIDTH // 2, self.HEIGHT // 2
        self.FPS = 60
        self.screen = pg.display.set_mode(self.RES)
        self.clock = pg.time.Clock()
        self.create_objects()

    def create_objects(self):
        self.camera = Camera(self, [0, 5, -35])
        self.projection = Projection(self)
        self.object = self.get_object_from_file('Modelos3D/mariotroph.obj')
        # self.object.rotate_y(-math.pi / 4)

    def get_object_from_file(self, filename):
        vertex, faces = [], []
        with open(filename) as f:
            for line in f:
                if line.startswith('v '):
                    vertex.append([float(i) for i in line.split()[1:]] + [1])
                elif line.startswith('f'):
                    faces_ = line.split()[1:]
                    faces.append([int(face_.split('/')[0]) - 1 for face_ in faces_])
        return Object3D(self, vertex, faces)

    def draw(self):
        self.screen.fill(pg.Color('gray10'))
        self.object.draw()

    def run(self):
        running = True
        _event = {
            'wheel': "",
            'pos': {
                'xy1': (),
                'xy2': ()
            }
        }
        while running:
            self.draw()
            self.camera.control(event=_event)
            for event in pg.event.get():
                mouse_pos = pg.mouse.get_pos()
                if event.type == pg.QUIT:
                    running = False
                if event.type == pg.MOUSEBUTTONDOWN:
                    _event['pos']['xy1'] = (mouse_pos[0] - 10, mouse_pos[1] - 100)
                elif event.type == pg.MOUSEBUTTONUP:
                    _event['pos']['xy2'] = (mouse_pos[0] - 10, mouse_pos[1] - 100)
                    # if _event['pos']['xy2'][1] < _event['pos']['xy1'][1]:  # x2 < x1
                    #     if _event['pos']['xy2'][0] < _event['pos']['xy1'][0]:  # y2 < y1
                    #         self.object.direction = "right"
                    #     else:
                    #         self.object.direction = "down"
                    # elif _event['pos']['xy2'][1] > _event['pos']['xy1'][1]:  # x2 > x1
                    #     if _event['pos']['xy2'][0] > _event['pos']['xy1'][0]:  # y2 > y1
                    #         self.object.direction = "left"
                    #     else:
                    #         self.object.direction = "up"
                    # else:
                    #     self.object.direction = "none"
                    # # print(_event['pos'])
                    # # print(pg.mouse.get_rel())
                if event.type == pg.MOUSEWHEEL:
                    # x: 0, y: -1 => MOUSEWHEELBACK == "Zoom Out"
                    # x: 0, y: 1 => MOUSEWHEELFRONT == "Zoom In"
                    if event.y == -1:
                        _event['wheel'] = "in"
                    elif event.y == 1:
                        _event['wheel'] = "out"
                    else:
                        _event['wheel'] = "none"



            pg.display.set_caption(f"FPS: {self.clock.get_fps()}")
            pg.display.flip()
            self.clock.tick(self.FPS)


if __name__ == '__main__':
    app = ObjectManipulator()
    app.run()
