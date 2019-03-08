# 此文件放与Assets的同级目录下
# 程序中调用资源时，根据此文件生成的txt进行访问，防止资源路径修改导致引用错误
import os

# 遍历目录，输出所有文件目录
# dir：搜索节点
# dir2：截取节点
def traversaldir(dir,dir2):
    pathlist = []
    childlist = os.listdir(dir)  # 列出文件夹下所有的目录与文件
    for i in range(0, len(childlist)):
        path = os.path.join(dir, childlist[i])
        if os.path.isfile(path):
            if os.path.splitext(path)[-1] != '.meta':   # 过滤掉Unity生成的meta
                (filepath, filename) = os.path.split(path)
                path = path.replace(dir2 + "\\","")     #去截取目录
                path = path.split('.')[0]               #去后缀
                path = path.replace("\\","/")               #反斜杠替换
                pathlist.append(filename + ',' + path + '\n')
        else:
            pathlist.extend(traversaldir(path,dir2))
    return pathlist

# 判断list是否有重复项,如果有则输出重复项
def checklistrepeat(l):
    setlist = list(set(l))
    if(len(setlist) == len(l)):
        print("列表没有重复项")
        return True
    else:
        print("列表存在重复项，重复项为：")
        d = defaultdict(list)

        for k, va in [(v, i) for i, v in enumerate(s)]:
            d[k].append(va)

        for k in d:
            if len(d[k]) > 1:
                print(d[k])
        return False


# 生成子：资源名 资源路径 格式的txt文件
d = os.path.dirname(__file__)  #返回当前文件所在的目录
rootdir = d + '/Assets/Resources'
file = open(rootdir + '/Text/ResourceDir.txt','w',encoding='utf-8')   #输出的目录文件
paths = traversaldir(rootdir,rootdir)
filenames = []
for i in range(len(paths)):

    filenames.append(paths[i].split(',')[0])
if(len(paths) > 0):
    paths[-1].replace("\n", "")
file.writelines(paths)
file.close()

# 检查是否有重复命名文件

print("路径文件生成完毕，检测结果：")
checklistrepeat(filenames)



