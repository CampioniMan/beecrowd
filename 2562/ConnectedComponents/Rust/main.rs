use std::io::{BufRead, stdin};

#[allow(unused_macros)]
macro_rules! read {
    ($out:ident as $type:ty) => {
        let mut inner = String::new();
        std::io::stdin().read_line(&mut inner).expect("A String");
        let $out = inner.trim().parse::<$type>().expect("Parsable");
    };
}

fn get_line() -> String{
    let mut input = String::new();
    match stdin().read_line(&mut input) {
        Ok(_goes_into_input_above) => {},
        Err(_no_updates_is_fine) => {},
    }
    input.trim().to_string()
}

fn find_leader(leader_indexes: &mut Vec<u32>, child_index: u32) -> u32{
    if child_index == leader_indexes[child_index as usize] {
        return child_index;
    }
    leader_indexes[child_index as usize] = find_leader(leader_indexes, leader_indexes[child_index as usize]);
    return leader_indexes[child_index as usize];
}

fn main() {
    let reader = stdin();
    let mut lines = reader.lock().lines();
    while let Some(line) = lines.next() {

        let unwrapped_line = line.unwrap();
        let inputs: Vec<u32> = unwrapped_line.split(" ")
            .map(|x| x.parse().expect("Not an integer!"))
            .collect();
        let n = inputs[0];
        let m = inputs[1];

        let mut component_sizes: Vec<u32> = vec![1; n as usize];
        let mut leader_indexes: Vec<u32> = (0..n).collect();

        for _ in 0..m {
            let line = lines
                .next()
                .expect("there was no next line")
                .expect("the line could not be read");
            let inputs: Vec<u32> = line.split(" ")
                .map(|x| x.parse().expect("Not an integer!"))
                .collect();
            let specie_a_id = inputs[0];
            let specie_b_id = inputs[1];
            if specie_a_id == specie_b_id {
                continue;
            }

            let mut largest_leader = find_leader(&mut leader_indexes, specie_a_id - 1);
            let mut smallest_leader = find_leader(&mut leader_indexes, specie_b_id - 1);
            if largest_leader == smallest_leader {
                continue;
            }

            if component_sizes[smallest_leader as usize] > component_sizes[largest_leader as usize] {
                let temp = smallest_leader;
                smallest_leader = largest_leader;
                largest_leader = temp;
            }

            leader_indexes[smallest_leader as usize] = largest_leader;
            component_sizes[largest_leader as usize] += component_sizes[smallest_leader as usize];
        }

        let line = lines
            .next()
            .expect("there was no next line")
            .expect("the line could not be read");
        let captured_specie = line.trim().parse::<u32>().expect("Parsable");
        println!("{}", component_sizes[find_leader(&mut leader_indexes, captured_specie - 1)  as usize]);
    }
}
