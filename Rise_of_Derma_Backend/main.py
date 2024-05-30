from flask import Flask, request

app = Flask(__name__)


@app.route("/get_top_list", methods=["POST"])
def get_top_list():
    top_list = []
    
    # Open the file and read the lines
    with open("./toplist.csv", "r") as f:
        for line in f:
            top_list.append(line.strip().split(";"))
    
    # Convert values
    for i in range(len(top_list)):
        top_list[i][0] = int(top_list[i][0])
        # Convert seconds to minutes and seconds
        top_list[i][1] = f"{int(top_list[i][1]) // 60}:{str(int(top_list[i][1]) % 60).zfill(2)}"

    # Return the top list
    return {"top_list": top_list}

@app.route("/send_result", methods=["POST"])
def add_to_top_list():
    # Get the name and time from the request body form-data
    data = request.json
    name = data["name"]
    time = int(data["time"])
    
    # Open the file and read the lines
    top_list = []
    with open("./toplist.csv", "r") as f:
        for line in f:
            top_list.append(line.strip().split(";"))

    # Convert values
    for i in range(len(top_list)):
        top_list[i][0] = int(top_list[i][0])
        top_list[i][1] = int(top_list[i][1])
        
    # If the result is better than one of the top results, add it to the list to the correct position
    for i in range(len(top_list)):
        if time < top_list[i][1]:
            top_list.insert(i, [i+1, time, name])
            break
    
    # Reorder the list
    for i in range(len(top_list)):
        top_list[i][0] = i+1
        
    # If the list is longer than 10, remove the last element
    if len(top_list) > 10:
        top_list.pop()
        
    # Write the top list to the file
    with open("./toplist.csv", "w") as f:
        for i in range(len(top_list)):
            f.write(f"{top_list[i][0]};{top_list[i][1]};{top_list[i][2]}\n")
        f.close()
    
    # Return success
    return {"success": True}

if __name__ == "__main__":
    app.run()