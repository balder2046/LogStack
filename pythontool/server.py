import socket
import sys
import threading
host = '0.0.0.0'
port = 8888
server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
print("socket create successfully!")
server.bind((host,port))
print("bind " + str(port) + " ok")
server.listen(10)
def getLogName():
    return "game.log"
def handleclient(conn,addrs):
    filew = open(getLogName(),"wb")
    data = conn.recv(1024)
    while (len(data) > 0):
        # print(data.decode('utf-8'))
        data = conn.recv(1024)
        filew.write(data)
    print("close from " + addr[0] + ":" + str(addr[1]))
    filew.close()
while True:
    print("wait for new connection")
    conn, addr = server.accept()
    print( "connected from " + addr[0] + ":" + str(addr[1]))
    #handleclient(conn,addr)
    th = threading.Thread(target=handleclient,args=(conn,addr))
    th.start()


