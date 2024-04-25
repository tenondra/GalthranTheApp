import {VStack, Input, Center, FormLabel, FormControl} from "@chakra-ui/react";
import DividerText from "../components/DividerText.tsx";

export default function NewGameImport() {
	return (
		<>
			<VStack width="100vw" height="100vh" spacing={{base: 12, md: 16}} divider={<DividerText text={"OR"}/>} padding={8}>

				<Center w={"50vw"}>
					<Input placeholder={"Url or BGG Id"}/>
				</Center>

				<Center w={"50vw"}>
					<FormControl>
						<FormLabel>Game name</FormLabel>
						<Input type={"text"} required={true} placeholder={"Brass: Birmingham"}/>

							<FormLabel>Rules</FormLabel>
							<Input type={"file"}/>
							<DividerText text={"OR"} py={"2"}/>
							<Input type={"url"}/>


						<FormLabel>Year of release</FormLabel>
						<Input type={"date"}/>
					</FormControl>

				</Center>


			</VStack>
		</>
	)
}