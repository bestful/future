from scipy.optimize import linprog	
import time
start = time.time()
c = [7, 3, 6,4,8,2,1,5,9]
A_ub = [[1, 1, 1, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 1, 1, 1, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 1, 1, 1]] 
b_ub = [74, 40, 36]  
A_eq = [[1, 0, 0, 1, 0, 0, 1, 0, 0],
        [0, 1, 0, 0, 1, 0, 0, 1, 0],
        [0, 0, 1, 0, 0, 1, 0, 0, 1]] 
b_eq = [20, 45, 30] 
print(linprog(c, A_ub, b_ub, A_eq, b_eq))
stop = time.time()
print ("Время :")
print(stop - start)